using System;
using System.Collections.Generic;
using System.Linq;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Intercambio;
using ElAhorrador.Negocio.Seguridad;

namespace ElAhorrador.Negocio.Servicios
{
    public class ServicioInventario
    {
        private readonly IRepositorioInventario _repositorioInventario;
        private readonly IRepositorioCatalogos _repositorioCatalogos;

        public ServicioInventario(IRepositorioInventario repositorioInventario, IRepositorioCatalogos repositorioCatalogos)
        {
            _repositorioInventario = repositorioInventario;
            _repositorioCatalogos = repositorioCatalogos;
        }

        public int ObtenerSiguienteConfirmacion()
        {
            var usuario = SesionActual.UsuarioActivo;
            if (usuario == null)
            {
                return 1;
            }
            return _repositorioInventario.SiguienteNumeroConfirmacionEntrada(usuario.IdUsuario);
        }

        public DetalleEntradaCalculado PrecalcularDetalle(decimal esperada, decimal recibida, decimal aceptada)
        {
            decimal faltante = Math.Max(esperada - recibida, 0m);
            decimal noAceptada = Math.Max(recibida - aceptada, 0m);
            return new DetalleEntradaCalculado
            {
                CantidadFaltante = faltante,
                CantidadNoAceptada = noAceptada,
                ResultadoVerificacion = (faltante > 0m || noAceptada > 0m) ? "CON_INCIDENCIA" : "CONFORME"
            };
        }

        public ResultadoRegistro RegistrarEntrada(ComandoEntrada comando)
        {
            var usuario = SesionActual.UsuarioActivo;
            if (usuario == null || !usuario.ValidarEstado())
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Debe iniciar sesión para registrar una entrada." };
            }

            if (comando.Tipo == "COMPRA_PROVEEDOR")
            {
                if (string.IsNullOrWhiteSpace(comando.Proveedor))
                {
                    return new ResultadoRegistro { Exito = false, Mensaje = "Ingrese el nombre del proveedor de origen." };
                }
                comando.IdLocalOrigen = null;
            }
            else if (comando.Tipo == "DEVOLUCION_LOCAL")
            {
                if (!comando.IdLocalOrigen.HasValue || comando.IdLocalOrigen.Value < 1 || comando.IdLocalOrigen.Value > 6)
                {
                    return new ResultadoRegistro { Exito = false, Mensaje = "Seleccione el local de origen de la devolución." };
                }
                comando.Proveedor = null;
            }
            else
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Seleccione un tipo de entrada válido." };
            }

            if (string.IsNullOrWhiteSpace(comando.Conductor) || string.IsNullOrWhiteSpace(comando.Placa))
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Complete los datos del conductor y la placa del vehículo." };
            }

            if (comando.CantidadEsperada <= 0m || comando.CantidadRecibida <= 0m)
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Las cantidades esperada y recibida deben ser mayores a cero." };
            }

            if (comando.CantidadAceptada < 0m || comando.CantidadAceptada > comando.CantidadRecibida)
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "La cantidad aceptada debe estar entre cero y la cantidad recibida." };
            }

            var producto = _repositorioCatalogos.ListarProductos().FirstOrDefault(p => p.IdProducto == comando.IdProducto);
            if (producto == null || !producto.Estado)
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Seleccione un producto activo." };
            }

            var unidad = _repositorioCatalogos.ListarUnidadesStockActivas().FirstOrDefault(u => u.IdUnidadMedida == comando.IdUnidadMedida);
            if (unidad == null)
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Seleccione una unidad de control de stock activa." };
            }

            if (unidad.DecimalesPermitidos == 0)
            {
                if (comando.CantidadEsperada % 1 != 0 || comando.CantidadRecibida % 1 != 0 || comando.CantidadAceptada % 1 != 0)
                {
                    return new ResultadoRegistro
                    {
                        Exito = false,
                        Mensaje = $"La unidad '{unidad.Simbolo}' solo admite cantidades enteras sin decimales."
                    };
                }
            }

            var ubicacion = _repositorioCatalogos.ListarUbicacionesActivas().FirstOrDefault(u => u.IdUbicacion == comando.IdUbicacion);
            if (ubicacion == null)
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Seleccione una ubicación activa." };
            }

            if (!string.Equals(producto.ConservacionRequerida, ubicacion.TipoConservacion, StringComparison.OrdinalIgnoreCase))
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = $"El producto '{producto.Nombre}' requiere conservación {producto.ConservacionRequerida} y la ubicación {ubicacion.Codigo} es {ubicacion.TipoConservacion}."
                };
            }

            bool prodLimpieza = producto.Clasificacion == "LIMPIEZA_HOGAR";
            bool zonaLimpieza = ubicacion.ClasificacionZona == "LIMPIEZA_HOGAR";
            if (prodLimpieza != zonaLimpieza)
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = "Los productos de limpieza deben almacenarse separados de alimentos e higiene personal."
                };
            }

            var calculo = PrecalcularDetalle(comando.CantidadEsperada, comando.CantidadRecibida, comando.CantidadAceptada);

            if (comando.CantidadAceptada > 0m)
            {
                if (producto.ControlLote)
                {
                    if (string.IsNullOrWhiteSpace(comando.Lote))
                    {
                        calculo.LoteFinal = $"INT-{DateTime.Now:yyyyMMdd}-{comando.NumeroConfirmacion:D2}";
                        calculo.OrigenLote = "INTERNO";
                    }
                    else
                    {
                        calculo.LoteFinal = comando.Lote.Trim().ToUpperInvariant();
                        calculo.OrigenLote = "FABRICANTE";
                    }
                }
                else if (!string.IsNullOrWhiteSpace(comando.Lote))
                {
                    calculo.LoteFinal = comando.Lote.Trim().ToUpperInvariant();
                    calculo.OrigenLote = "FABRICANTE";
                }

                if (producto.ControlVencimiento)
                {
                    if (comando.VencimientoComprobado)
                    {
                        if (!comando.Vencimiento.HasValue)
                        {
                            return new ResultadoRegistro { Exito = false, Mensaje = "Ingrese la fecha de vencimiento comprobada." };
                        }

                        if (comando.Vencimiento.Value < DateOnly.FromDateTime(DateTime.Today))
                        {
                            return new ResultadoRegistro
                            {
                                Exito = false,
                                Mensaje = "No se permite aceptar mercadería vencida. Indique cantidad aceptada igual a cero para registrar el rechazo."
                            };
                        }

                        calculo.VencimientoFinal = comando.Vencimiento.Value;
                        calculo.EstadoVerificacionVencimiento = "VERIFICADO";
                    }
                    else
                    {
                        calculo.VencimientoFinal = null;
                        calculo.EstadoVerificacionVencimiento = "PENDIENTE";
                    }
                }
                else
                {
                    calculo.VencimientoFinal = null;
                    calculo.EstadoVerificacionVencimiento = "NO_REQUERIDO";
                }
            }

            return _repositorioInventario.RegistrarEntradaAtomica(usuario.IdUsuario, comando, calculo);
        }

        public List<FilaStock> ConsultarStock(FiltroStock filtro)
        {
            return _repositorioInventario.LeerStock(filtro);
        }

        public List<FilaGrupoStock> ConsultarGrupos(int idProducto, int idUnidadMedida, int idUbicacion)
        {
            return _repositorioInventario.LeerGruposPorExistencia(idProducto, idUnidadMedida, idUbicacion);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;
using ElAhorrador.Negocio.Seguridad;

namespace ElAhorrador.Negocio.Servicios
{
    public class ServicioCatalogos
    {
        private readonly IRepositorioCatalogos _repositorioCatalogos;

        public ServicioCatalogos(IRepositorioCatalogos repositorioCatalogos)
        {
            _repositorioCatalogos = repositorioCatalogos;
        }

        public List<Producto> ConsultarProductos(string filtro = "")
        {
            return _repositorioCatalogos.ListarProductos(filtro.Trim());
        }

        public List<Categoria> ListarCategoriasActivas()
        {
            return _repositorioCatalogos.ListarCategoriasActivas();
        }

        public List<UnidadControlStock> ListarUnidadesStockActivas()
        {
            return _repositorioCatalogos.ListarUnidadesStockActivas();
        }

        public List<Ubicacion> ListarUbicacionesActivas()
        {
            return _repositorioCatalogos.ListarUbicacionesActivas();
        }

        public List<Local> ListarLocales()
        {
            return _repositorioCatalogos.ListarLocales();
        }

        public ResultadoRegistro RegistrarProducto(DatosProducto datos)
        {
            var usuario = SesionActual.UsuarioActivo;
            if (usuario == null || !usuario.ValidarEstado())
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "No hay una sesión activa." };
            }

            if (!usuario.EsJefe)
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = "Solo el Jefe de Almacén tiene permisos para registrar productos."
                };
            }

            if (string.IsNullOrWhiteSpace(datos.Codigo) ||
                string.IsNullOrWhiteSpace(datos.Nombre) ||
                string.IsNullOrWhiteSpace(datos.PresentacionFisica) ||
                string.IsNullOrWhiteSpace(datos.Descripcion))
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = "Complete el código, nombre, presentación física y descripción del producto."
                };
            }

            if (_repositorioCatalogos.ExisteCodigoProducto(datos.Codigo))
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = $"El código '{datos.Codigo.Trim().ToUpperInvariant()}' ya está asignado a otro producto."
                };
            }

            var ubicaciones = _repositorioCatalogos.ListarUbicacionesActivas();
            var ubicacion = ubicaciones.FirstOrDefault(u => u.IdUbicacion == datos.IdUbicacionInicial);
            if (ubicacion == null)
            {
                return new ResultadoRegistro { Exito = false, Mensaje = "Seleccione una ubicación activa." };
            }

            if (!string.Equals(ubicacion.TipoConservacion, datos.ConservacionRequerida, StringComparison.OrdinalIgnoreCase))
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = $"La conservación requerida ({datos.ConservacionRequerida}) no es compatible con la ubicación {ubicacion.Codigo} ({ubicacion.TipoConservacion})."
                };
            }

            bool productoEsLimpieza = datos.Clasificacion == "LIMPIEZA_HOGAR";
            bool zonaEsLimpieza = ubicacion.ClasificacionZona == "LIMPIEZA_HOGAR";
            if (productoEsLimpieza != zonaEsLimpieza)
            {
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = "Los productos de limpieza del hogar deben ubicarse separados de los alimentos y productos de higiene personal."
                };
            }

            return _repositorioCatalogos.GuardarProductoAtomico(datos);
        }
    }
}

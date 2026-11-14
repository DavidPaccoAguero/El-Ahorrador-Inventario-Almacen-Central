using System;
using System.Collections.Generic;
using System.Data;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;
using Microsoft.Data.SqlClient;

namespace ElAhorrador.Datos
{
    public class RepositorioInventarioSql : IRepositorioInventario
    {
        private readonly ConexionSql _conexionSql;

        public RepositorioInventarioSql(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }

        public int SiguienteNumeroConfirmacionEntrada(int idUsuario)
        {
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT ISNULL(MAX(NumeroConfirmacion), 0) + 1
                FROM dbo.Entrada
                WHERE IdUsuarioRegistro = @IdUsuario;";

            using var cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public bool EstanAsociadosProductoUnidadUbicacion(int idProducto, int idUnidadMedida, int idUbicacion)
        {
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT CASE WHEN EXISTS (
                    SELECT 1 FROM dbo.ProductoUnidadControlStock
                    WHERE IdProducto = @IdProducto AND IdUnidadMedida = @IdUnidad AND Estado = 1
                ) AND EXISTS (
                    SELECT 1 FROM dbo.Existencia
                    WHERE IdProducto = @IdProducto AND IdUbicacion = @IdUbicacion AND Estado = 1
                ) THEN 1 ELSE 0 END;";

            using var cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdUnidad", idUnidadMedida);
            cmd.Parameters.AddWithValue("@IdUbicacion", idUbicacion);
            return Convert.ToInt32(cmd.ExecuteScalar()) == 1;
        }

        public ResultadoRegistro RegistrarEntradaAtomica(int idUsuario, ComandoEntrada comando, DetalleEntradaCalculado calculo)
        {
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();
            using var transaccion = conexion.BeginTransaction(IsolationLevel.Serializable);

            try
            {
                const string sqlExistente = @"
                    SELECT IdEntrada
                    FROM dbo.Entrada WITH (UPDLOCK, HOLDLOCK)
                    WHERE IdUsuarioRegistro = @IdUsuario AND NumeroConfirmacion = @NumeroConfirmacion;";

                using (var cmdExistente = new SqlCommand(sqlExistente, conexion, transaccion))
                {
                    cmdExistente.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmdExistente.Parameters.AddWithValue("@NumeroConfirmacion", comando.NumeroConfirmacion);
                    object? existente = cmdExistente.ExecuteScalar();
                    if (existente != null && existente != DBNull.Value)
                    {
                        int idPrevio = Convert.ToInt32(existente);
                        transaccion.Commit();
                        return new ResultadoRegistro
                        {
                            Exito = true,
                            IdGenerado = idPrevio,
                            CodigoFormateado = $"EN-{idPrevio:D5}",
                            Mensaje = $"La entrada EN-{idPrevio:D5} ya se encontraba registrada. No se duplicaron las existencias."
                        };
                    }
                }

                const string sqlAsegurarUnidad = @"
                    IF NOT EXISTS (SELECT 1 FROM dbo.ProductoUnidadControlStock WHERE IdProducto = @IdProducto AND IdUnidadMedida = @IdUnidad)
                        INSERT INTO dbo.ProductoUnidadControlStock (IdProducto, IdUnidadMedida, Estado) VALUES (@IdProducto, @IdUnidad, 1);";
                using (var cmdAsocU = new SqlCommand(sqlAsegurarUnidad, conexion, transaccion))
                {
                    cmdAsocU.Parameters.AddWithValue("@IdProducto", comando.IdProducto);
                    cmdAsocU.Parameters.AddWithValue("@IdUnidad", comando.IdUnidadMedida);
                    cmdAsocU.ExecuteNonQuery();
                }

                const string sqlAsegurarExistencia = @"
                    IF NOT EXISTS (SELECT 1 FROM dbo.Existencia WHERE IdProducto = @IdProducto AND IdUbicacion = @IdUbicacion)
                        INSERT INTO dbo.Existencia (IdProducto, IdUbicacion, Estado) VALUES (@IdProducto, @IdUbicacion, 1);";
                using (var cmdAsocE = new SqlCommand(sqlAsegurarExistencia, conexion, transaccion))
                {
                    cmdAsocE.Parameters.AddWithValue("@IdProducto", comando.IdProducto);
                    cmdAsocE.Parameters.AddWithValue("@IdUbicacion", comando.IdUbicacion);
                    cmdAsocE.ExecuteNonQuery();
                }

                const string sqlEntrada = @"
                    INSERT INTO dbo.Entrada
                        (NumeroConfirmacion, FechaHora, Tipo, Proveedor, IdLocalOrigen, Conductor, Placa, Observaciones, IdUsuarioRegistro)
                    OUTPUT INSERTED.IdEntrada
                    VALUES
                        (@NumeroConfirmacion, SYSDATETIME(), @Tipo, @Proveedor, @IdLocalOrigen, @Conductor, @Placa, @Observaciones, @IdUsuario);";

                int idEntrada;
                using (var cmdEntrada = new SqlCommand(sqlEntrada, conexion, transaccion))
                {
                    cmdEntrada.Parameters.AddWithValue("@NumeroConfirmacion", comando.NumeroConfirmacion);
                    cmdEntrada.Parameters.AddWithValue("@Tipo", comando.Tipo);
                    cmdEntrada.Parameters.AddWithValue("@Proveedor", string.IsNullOrWhiteSpace(comando.Proveedor) ? DBNull.Value : comando.Proveedor.Trim());
                    cmdEntrada.Parameters.AddWithValue("@IdLocalOrigen", comando.IdLocalOrigen.HasValue ? comando.IdLocalOrigen.Value : DBNull.Value);
                    cmdEntrada.Parameters.AddWithValue("@Conductor", comando.Conductor.Trim());
                    cmdEntrada.Parameters.AddWithValue("@Placa", comando.Placa.Trim().ToUpperInvariant());
                    cmdEntrada.Parameters.AddWithValue("@Observaciones", string.IsNullOrWhiteSpace(comando.Observaciones) ? DBNull.Value : comando.Observaciones.Trim());
                    cmdEntrada.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    idEntrada = Convert.ToInt32(cmdEntrada.ExecuteScalar());
                }

                const string sqlDetalle = @"
                    INSERT INTO dbo.DetalleEntrada
                        (IdEntrada, Renglon, IdProducto, IdUnidadMedida, IdUbicacion, CantidadEsperada, CantidadRecibida, CantidadAceptada, ResultadoVerificacion)
                    OUTPUT INSERTED.IdDetalleEntrada
                    VALUES
                        (@IdEntrada, 1, @IdProducto, @IdUnidad, @IdUbicacion, @Esperada, @Recibida, @Aceptada, @Resultado);";

                int idDetalle;
                using (var cmdDetalle = new SqlCommand(sqlDetalle, conexion, transaccion))
                {
                    cmdDetalle.Parameters.AddWithValue("@IdEntrada", idEntrada);
                    cmdDetalle.Parameters.AddWithValue("@IdProducto", comando.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@IdUnidad", comando.IdUnidadMedida);
                    cmdDetalle.Parameters.AddWithValue("@IdUbicacion", comando.IdUbicacion);
                    cmdDetalle.Parameters.AddWithValue("@Esperada", comando.CantidadEsperada);
                    cmdDetalle.Parameters.AddWithValue("@Recibida", comando.CantidadRecibida);
                    cmdDetalle.Parameters.AddWithValue("@Aceptada", comando.CantidadAceptada);
                    cmdDetalle.Parameters.AddWithValue("@Resultado", calculo.ResultadoVerificacion);
                    idDetalle = Convert.ToInt32(cmdDetalle.ExecuteScalar());
                }

                int? idGrupoGenerado = null;
                if (comando.CantidadAceptada > 0)
                {
                    const string sqlGrupo = @"
                        INSERT INTO dbo.GrupoExistencia
                            (IdProducto, IdUnidadMedida, IdUbicacion, IdDetalleEntrada, FechaRecepcion, Lote, OrigenLote, Vencimiento, EstadoVerificacionVencimiento, CantidadRegistrada)
                        OUTPUT INSERTED.IdGrupo
                        VALUES
                            (@IdProducto, @IdUnidad, @IdUbicacion, @IdDetalle, SYSDATETIME(), @Lote, @OrigenLote, @Vencimiento, @EstadoVerificacion, @CantidadAceptada);";

                    using var cmdGrupo = new SqlCommand(sqlGrupo, conexion, transaccion);
                    cmdGrupo.Parameters.AddWithValue("@IdProducto", comando.IdProducto);
                    cmdGrupo.Parameters.AddWithValue("@IdUnidad", comando.IdUnidadMedida);
                    cmdGrupo.Parameters.AddWithValue("@IdUbicacion", comando.IdUbicacion);
                    cmdGrupo.Parameters.AddWithValue("@IdDetalle", idDetalle);
                    cmdGrupo.Parameters.AddWithValue("@Lote", string.IsNullOrWhiteSpace(calculo.LoteFinal) ? DBNull.Value : calculo.LoteFinal);
                    cmdGrupo.Parameters.AddWithValue("@OrigenLote", string.IsNullOrWhiteSpace(calculo.OrigenLote) ? DBNull.Value : calculo.OrigenLote);
                    cmdGrupo.Parameters.AddWithValue("@Vencimiento", calculo.VencimientoFinal.HasValue ? calculo.VencimientoFinal.Value.ToDateTime(TimeOnly.MinValue) : DBNull.Value);
                    cmdGrupo.Parameters.AddWithValue("@EstadoVerificacion", calculo.EstadoVerificacionVencimiento);
                    cmdGrupo.Parameters.AddWithValue("@CantidadAceptada", comando.CantidadAceptada);
                    idGrupoGenerado = Convert.ToInt32(cmdGrupo.ExecuteScalar());
                }

                string codigoEntrada = $"EN-{idEntrada:D5}";
                string resumenEntrada = comando.CantidadAceptada > 0
                    ? $"Entrada {codigoEntrada} registrada: {comando.CantidadAceptada:0.###} unidades aceptadas."
                    : $"Recepción {codigoEntrada} sin aceptación: {comando.CantidadRecibida:0.###} recibidas, 0 aceptadas.";

                const string sqlHistEntrada = @"
                    INSERT INTO dbo.HistorialOperacion (TipoOperacion, FechaHora, IdUsuario, Resumen, IdEntrada, IdIncidencia)
                    VALUES ('ENTRADA', SYSDATETIME(), @IdUsuario, @Resumen, @IdEntrada, NULL);";
                using (var cmdHistE = new SqlCommand(sqlHistEntrada, conexion, transaccion))
                {
                    cmdHistE.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmdHistE.Parameters.AddWithValue("@Resumen", resumenEntrada);
                    cmdHistE.Parameters.AddWithValue("@IdEntrada", idEntrada);
                    cmdHistE.ExecuteNonQuery();
                }

                if (calculo.CantidadFaltante > 0)
                {
                    InsertarIncidenciaYEvento(conexion, transaccion, idDetalle, idUsuario, "FALTANTE", calculo.CantidadFaltante,
                        string.IsNullOrWhiteSpace(comando.ObservacionIncidencia)
                            ? "Diferencia respecto de la cantidad esperada."
                            : comando.ObservacionIncidencia.Trim());
                }

                if (calculo.CantidadNoAceptada > 0)
                {
                    InsertarIncidenciaYEvento(conexion, transaccion, idDetalle, idUsuario, "NO_ACEPTADO", calculo.CantidadNoAceptada,
                        string.IsNullOrWhiteSpace(comando.ObservacionIncidencia)
                            ? "Cantidad no aceptada durante la verificación física."
                            : comando.ObservacionIncidencia.Trim());
                }

                transaccion.Commit();

                string detalleMensaje = comando.CantidadAceptada == 0
                    ? $"Se guardaron {comando.CantidadRecibida:0.###} unidades recibidas, 0 aceptadas y sus incidencias. No se incorporaron existencias."
                    : $"Entrada {codigoEntrada} registrada: {comando.CantidadAceptada:0.###} unidades aceptadas" +
                      (calculo.CantidadFaltante > 0 ? $" y {calculo.CantidadFaltante:0.###} unidades faltantes registradas como incidencia" : "") +
                      (calculo.CantidadNoAceptada > 0 ? $" y {calculo.CantidadNoAceptada:0.###} unidades no aceptadas registradas como incidencia" : "") + ".";

                return new ResultadoRegistro
                {
                    Exito = true,
                    IdGenerado = idEntrada,
                    CodigoFormateado = codigoEntrada,
                    Mensaje = detalleMensaje
                };
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = $"No se pudo guardar la entrada: {ex.Message}"
                };
            }
        }

        private static void InsertarIncidenciaYEvento(SqlConnection conexion, SqlTransaction transaccion, int idDetalle, int idUsuario, string tipo, decimal cantidad, string observacion)
        {
            const string sqlInc = @"
                INSERT INTO dbo.IncidenciaRecepcion (IdDetalleEntrada, Tipo, CantidadAfectada, Observaciones, FechaHora, IdUsuarioRegistro)
                OUTPUT INSERTED.IdIncidencia
                VALUES (@IdDetalle, @Tipo, @Cantidad, @Observaciones, SYSDATETIME(), @IdUsuario);";

            int idIncidencia;
            using (var cmdInc = new SqlCommand(sqlInc, conexion, transaccion))
            {
                cmdInc.Parameters.AddWithValue("@IdDetalle", idDetalle);
                cmdInc.Parameters.AddWithValue("@Tipo", tipo);
                cmdInc.Parameters.AddWithValue("@Cantidad", cantidad);
                cmdInc.Parameters.AddWithValue("@Observaciones", observacion);
                cmdInc.Parameters.AddWithValue("@IdUsuario", idUsuario);
                idIncidencia = Convert.ToInt32(cmdInc.ExecuteScalar());
            }

            const string sqlHistInc = @"
                INSERT INTO dbo.HistorialOperacion (TipoOperacion, FechaHora, IdUsuario, Resumen, IdEntrada, IdIncidencia)
                VALUES ('INCIDENCIA', SYSDATETIME(), @IdUsuario, @Resumen, NULL, @IdIncidencia);";

            using var cmdHistI = new SqlCommand(sqlHistInc, conexion, transaccion);
            cmdHistI.Parameters.AddWithValue("@IdUsuario", idUsuario);
            cmdHistI.Parameters.AddWithValue("@Resumen", $"Incidencia IN-{idIncidencia:D5}: {cantidad:0.###} unidades ({tipo}).");
            cmdHistI.Parameters.AddWithValue("@IdIncidencia", idIncidencia);
            cmdHistI.ExecuteNonQuery();
        }

        public List<FilaStock> LeerStock(FiltroStock filtro)
        {
            var lista = new List<FilaStock>();
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT IdProducto, CodigoProducto, NombreProducto,
                       IdUnidadMedida, UnidadControl,
                       IdUbicacion, CodigoUbicacion,
                       Registrada, Habilitada
                FROM dbo.vw_Existencia
                WHERE (@IdProducto IS NULL OR IdProducto = @IdProducto)
                  AND (@IdUbicacion IS NULL OR IdUbicacion = @IdUbicacion)
                ORDER BY CodigoProducto, UnidadControl, CodigoUbicacion
                OFFSET 0 ROWS FETCH NEXT 100 ROWS ONLY;";

            using var cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@IdProducto", filtro.IdProducto.HasValue ? filtro.IdProducto.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@IdUbicacion", filtro.IdUbicacion.HasValue ? filtro.IdUbicacion.Value : DBNull.Value);

            using var lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new FilaStock
                {
                    IdProducto = lector.GetInt32(0),
                    CodigoProducto = lector.GetString(1),
                    NombreProducto = lector.GetString(2),
                    IdUnidadMedida = lector.GetInt32(3),
                    UnidadControl = lector.GetString(4),
                    IdUbicacion = lector.GetInt32(5),
                    CodigoUbicacion = lector.GetString(6),
                    Registrada = lector.GetDecimal(7),
                    Habilitada = lector.GetDecimal(8)
                });
            }
            return lista;
        }

        public List<FilaGrupoStock> LeerGruposPorExistencia(int idProducto, int idUnidadMedida, int idUbicacion)
        {
            var lista = new List<FilaGrupoStock>();
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT IdGrupo, Lote, FechaRecepcion, Vencimiento,
                       EstadoVerificacionVencimiento, CantidadRegistrada, HabilitadoParaSalida
                FROM dbo.vw_GrupoExistencia
                WHERE IdProducto = @IdProducto
                  AND IdUnidadMedida = @IdUnidad
                  AND IdUbicacion = @IdUbicacion
                ORDER BY
                    CASE WHEN Vencimiento IS NULL THEN 1 ELSE 0 END,
                    Vencimiento ASC,
                    FechaRecepcion ASC,
                    IdGrupo ASC;";

            using var cmd = new SqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@IdProducto", idProducto);
            cmd.Parameters.AddWithValue("@IdUnidad", idUnidadMedida);
            cmd.Parameters.AddWithValue("@IdUbicacion", idUbicacion);

            using var lector = cmd.ExecuteReader();
            while (lector.Read())
            {
                int idGrupo = lector.GetInt32(0);
                string lote = lector.GetString(1);
                DateTime fechaRec = lector.GetDateTime(2);
                DateOnly? venc = lector.IsDBNull(3) ? null : DateOnly.FromDateTime(lector.GetDateTime(3));
                string estadoVerif = lector.GetString(4);
                decimal cantidad = lector.GetDecimal(5);
                bool habilitado = lector.GetBoolean(6);

                lista.Add(new FilaGrupoStock
                {
                    IdGrupo = idGrupo,
                    GrupoLote = $"{idGrupo} - {lote}",
                    Recepcion = fechaRec.ToString("dd/MM/yyyy"),
                    Vencimiento = venc.HasValue ? venc.Value.ToString("dd/MM/yyyy") : "Pendiente",
                    Verificacion = estadoVerif == "VERIFICADO" ? "Verificado" : (estadoVerif == "PENDIENTE" ? "Pendiente" : "No requerido"),
                    Cantidad = cantidad,
                    Habilitado = habilitado,
                    CondicionDespacho = habilitado ? "Habilitado" : "Bloqueado para salida"
                });
            }
            return lista;
        }
    }
}

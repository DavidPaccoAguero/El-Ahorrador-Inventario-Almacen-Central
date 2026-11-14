using System;
using System.Collections.Generic;
using ElAhorrador.Negocio.Contratos;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;
using Microsoft.Data.SqlClient;

namespace ElAhorrador.Datos
{
    public class RepositorioCatalogosSql : IRepositorioCatalogos
    {
        private readonly ConexionSql _conexionSql;

        public RepositorioCatalogosSql(ConexionSql conexionSql)
        {
            _conexionSql = conexionSql;
        }

        public List<Producto> ListarProductos(string filtro = "")
        {
            var lista = new List<Producto>();

            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT p.IdProducto, p.Codigo, p.Nombre, p.Descripcion, p.PresentacionFisica,
                       p.IdCategoria, c.Nombre AS NombreCategoria, p.Clasificacion,
                       p.ConservacionRequerida, p.ControlLote, p.ControlVencimiento, p.Estado
                FROM dbo.Producto p
                INNER JOIN dbo.Categoria c ON c.IdCategoria = p.IdCategoria
                WHERE (@Filtro = N'' OR p.Codigo LIKE N'%' + @Filtro + N'%' OR p.Nombre LIKE N'%' + @Filtro + N'%')
                ORDER BY p.Codigo;";

            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Filtro", filtro);

            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Producto
                {
                    IdProducto = lector.GetInt32(0),
                    Codigo = lector.GetString(1),
                    Nombre = lector.GetString(2),
                    Descripcion = lector.GetString(3),
                    PresentacionFisica = lector.GetString(4),
                    IdCategoria = lector.GetInt32(5),
                    NombreCategoria = lector.GetString(6),
                    Clasificacion = lector.GetString(7),
                    ConservacionRequerida = lector.GetString(8),
                    ControlLote = lector.GetBoolean(9),
                    ControlVencimiento = lector.GetBoolean(10),
                    Estado = lector.GetBoolean(11)
                });
            }

            return lista;
        }

        public List<Categoria> ListarCategoriasActivas()
        {
            var lista = new List<Categoria>();
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT IdCategoria, Nombre, Descripcion, Estado, IdCategoriaSuperior
                FROM dbo.Categoria
                WHERE Estado = 1
                ORDER BY Nombre;";

            using var comando = new SqlCommand(sql, conexion);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Categoria
                {
                    IdCategoria = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Descripcion = lector.GetString(2),
                    Estado = lector.GetBoolean(3),
                    IdCategoriaSuperior = lector.IsDBNull(4) ? null : lector.GetInt32(4)
                });
            }
            return lista;
        }

        public List<UnidadControlStock> ListarUnidadesStockActivas()
        {
            var lista = new List<UnidadControlStock>();
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT ucs.IdUnidadMedida, um.Nombre, um.Simbolo, ucs.Descripcion, ucs.DecimalesPermitidos, ucs.Estado
                FROM dbo.UnidadControlStock ucs
                INNER JOIN dbo.UnidadMedida um ON um.IdUnidadMedida = ucs.IdUnidadMedida
                WHERE ucs.Estado = 1 AND um.Estado = 1
                ORDER BY um.IdUnidadMedida;";

            using var comando = new SqlCommand(sql, conexion);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new UnidadControlStock
                {
                    IdUnidadMedida = lector.GetInt32(0),
                    Nombre = lector.GetString(1),
                    Simbolo = lector.GetString(2),
                    Descripcion = lector.GetString(3),
                    DecimalesPermitidos = lector.GetByte(4),
                    Estado = lector.GetBoolean(5)
                });
            }
            return lista;
        }

        public List<Ubicacion> ListarUbicacionesActivas()
        {
            var lista = new List<Ubicacion>();
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = @"
                SELECT u.IdUbicacion, u.Codigo, u.Nombre, u.Descripcion, u.IdZona, z.Nombre, z.Clasificacion, u.TipoConservacion, u.Estado
                FROM dbo.Ubicacion u
                INNER JOIN dbo.Zona z ON z.IdZona = u.IdZona
                WHERE u.Estado = 1 AND z.Estado = 1
                ORDER BY u.Codigo;";

            using var comando = new SqlCommand(sql, conexion);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Ubicacion
                {
                    IdUbicacion = lector.GetInt32(0),
                    Codigo = lector.GetString(1),
                    Nombre = lector.GetString(2),
                    Descripcion = lector.GetString(3),
                    IdZona = lector.GetInt32(4),
                    NombreZona = lector.GetString(5),
                    ClasificacionZona = lector.GetString(6),
                    TipoConservacion = lector.GetString(7),
                    Estado = lector.GetBoolean(8)
                });
            }
            return lista;
        }

        public List<Local> ListarLocales()
        {
            var lista = new List<Local>();
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = "SELECT IdLocal, Nombre FROM dbo.Local ORDER BY IdLocal;";
            using var comando = new SqlCommand(sql, conexion);
            using var lector = comando.ExecuteReader();
            while (lector.Read())
            {
                lista.Add(new Local
                {
                    IdLocal = lector.GetInt32(0),
                    Nombre = lector.GetString(1)
                });
            }
            return lista;
        }

        public bool ExisteCodigoProducto(string codigo)
        {
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();

            const string sql = "SELECT COUNT(1) FROM dbo.Producto WHERE UPPER(Codigo) = UPPER(@Codigo);";
            using var comando = new SqlCommand(sql, conexion);
            comando.Parameters.AddWithValue("@Codigo", codigo.Trim());
            return Convert.ToInt32(comando.ExecuteScalar()) > 0;
        }

        public ResultadoRegistro GuardarProductoAtomico(DatosProducto datos)
        {
            using var conexion = _conexionSql.CrearConexion();
            conexion.Open();
            using var transaccion = conexion.BeginTransaction();

            try
            {
                const string sqlProducto = @"
                    INSERT INTO dbo.Producto
                        (Codigo, Nombre, Descripcion, PresentacionFisica, IdCategoria, Clasificacion, ConservacionRequerida, ControlLote, ControlVencimiento, Estado)
                    OUTPUT INSERTED.IdProducto
                    VALUES
                        (@Codigo, @Nombre, @Descripcion, @PresentacionFisica, @IdCategoria, @Clasificacion, @ConservacionRequerida, @ControlLote, @ControlVencimiento, 1);";

                using var cmdProd = new SqlCommand(sqlProducto, conexion, transaccion);
                cmdProd.Parameters.AddWithValue("@Codigo", datos.Codigo.Trim().ToUpperInvariant());
                cmdProd.Parameters.AddWithValue("@Nombre", datos.Nombre.Trim());
                cmdProd.Parameters.AddWithValue("@Descripcion", datos.Descripcion.Trim());
                cmdProd.Parameters.AddWithValue("@PresentacionFisica", datos.PresentacionFisica.Trim());
                cmdProd.Parameters.AddWithValue("@IdCategoria", datos.IdCategoria);
                cmdProd.Parameters.AddWithValue("@Clasificacion", datos.Clasificacion);
                cmdProd.Parameters.AddWithValue("@ConservacionRequerida", datos.ConservacionRequerida);
                cmdProd.Parameters.AddWithValue("@ControlLote", datos.ControlLote);
                cmdProd.Parameters.AddWithValue("@ControlVencimiento", datos.ControlVencimiento);

                int idProducto = Convert.ToInt32(cmdProd.ExecuteScalar());

                const string sqlUnidad = @"
                    INSERT INTO dbo.ProductoUnidadControlStock (IdProducto, IdUnidadMedida, Estado)
                    VALUES (@IdProducto, @IdUnidadMedida, 1);";
                using var cmdUnidad = new SqlCommand(sqlUnidad, conexion, transaccion);
                cmdUnidad.Parameters.AddWithValue("@IdProducto", idProducto);
                cmdUnidad.Parameters.AddWithValue("@IdUnidadMedida", datos.IdUnidadMedidaInicial);
                cmdUnidad.ExecuteNonQuery();

                const string sqlExistencia = @"
                    INSERT INTO dbo.Existencia (IdProducto, IdUbicacion, Estado)
                    VALUES (@IdProducto, @IdUbicacion, 1);";
                using var cmdExistencia = new SqlCommand(sqlExistencia, conexion, transaccion);
                cmdExistencia.Parameters.AddWithValue("@IdProducto", idProducto);
                cmdExistencia.Parameters.AddWithValue("@IdUbicacion", datos.IdUbicacionInicial);
                cmdExistencia.ExecuteNonQuery();

                transaccion.Commit();
                return new ResultadoRegistro
                {
                    Exito = true,
                    IdGenerado = idProducto,
                    CodigoFormateado = datos.Codigo.Trim().ToUpperInvariant(),
                    Mensaje = $"Producto {datos.Codigo.Trim().ToUpperInvariant()} registrado y asociado correctamente."
                };
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                return new ResultadoRegistro
                {
                    Exito = false,
                    Mensaje = $"No se pudo guardar el producto: {ex.Message}"
                };
            }
        }
    }
}

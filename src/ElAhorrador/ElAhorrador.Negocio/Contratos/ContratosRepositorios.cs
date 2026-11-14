using System;
using System.Collections.Generic;
using System.Text;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;

namespace ElAhorrador.Negocio.Contratos
{
    public interface IRepositorioUsuarios
    {
        Usuario? ObtenerPorNombre(string nombreUsuario);
    }

    public interface IRepositorioCatalogos
    {
        List<Producto> ListarProductos(string filtro = "");
        List<Categoria> ListarCategoriasActivas();
        List<UnidadControlStock> ListarUnidadesStockActivas();
        List<Ubicacion> ListarUbicacionesActivas();
        List<Local> ListarLocales();
        bool ExisteCodigoProducto(string codigo);
        ResultadoRegistro GuardarProductoAtomico(DatosProducto datos);
    }

    public interface IRepositorioInventario
    {
        int SiguienteNumeroConfirmacionEntrada(int idUsuario);
        bool EstanAsociadosProductoUnidadUbicacion(int idProducto, int idUnidadMedida, int idUbicacion);
        ResultadoRegistro RegistrarEntradaAtomica(int idUsuario, ComandoEntrada comando, DetalleEntradaCalculado calculo);
        List<FilaStock> LeerStock(FiltroStock filtro);
        List<FilaGrupoStock> LeerGruposPorExistencia(int idProducto, int idUnidadMedida, int idUbicacion);
    }
}

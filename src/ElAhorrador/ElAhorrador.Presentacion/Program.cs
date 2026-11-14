using System;
using System.Windows.Forms;
using ElAhorrador.Datos;
using ElAhorrador.Negocio.Servicios;

namespace ElAhorrador.Presentacion
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var conexionSql = new ConexionSql();
            var repositorioUsuarios = new RepositorioUsuariosSql(conexionSql);
            var repositorioCatalogos = new RepositorioCatalogosSql(conexionSql);
            var repositorioInventario = new RepositorioInventarioSql(conexionSql);

            var servicioUsuarios = new ServicioUsuarios(repositorioUsuarios);
            var servicioCatalogos = new ServicioCatalogos(repositorioCatalogos);
            var servicioInventario = new ServicioInventario(repositorioInventario, repositorioCatalogos);

            Application.Run(new FrmLogin(servicioUsuarios, servicioCatalogos, servicioInventario, conexionSql));
        }
    }
}

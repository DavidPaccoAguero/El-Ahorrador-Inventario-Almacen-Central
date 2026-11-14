using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;
using ElAhorrador.Negocio.Servicios;

namespace ElAhorrador.Presentacion
{
    public partial class FrmStock : Form
    {
        private readonly ServicioInventario _servicioInventario;
        private readonly ServicioCatalogos _servicioCatalogos;
        private List<FilaStock> _existenciasActuales = new List<FilaStock>();

        public FrmStock(ServicioInventario servicioInventario, ServicioCatalogos servicioCatalogos)
        {
            InitializeComponent();
            _servicioInventario = servicioInventario;
            _servicioCatalogos = servicioCatalogos;
        }

        private void FrmStock_Load(object sender, EventArgs e)
        {
            CargarFiltros();
            EjecutarConsultaStock();
        }

        private void CargarFiltros()
        {
            var productos = new List<Producto>
            {
                new Producto { IdProducto = 0, Codigo = "TODOS", Nombre = "Todos los productos" }
            };
            productos.AddRange(_servicioCatalogos.ConsultarProductos());
            cboFiltroProducto.DataSource = productos;
            cboFiltroProducto.DisplayMember = "EtiquetaCombo";
            cboFiltroProducto.ValueMember = "IdProducto";

            var ubicaciones = new List<Ubicacion>
            {
                new Ubicacion { IdUbicacion = 0, Codigo = "TODAS", Nombre = "Todas las ubicaciones" }
            };
            ubicaciones.AddRange(_servicioCatalogos.ListarUbicacionesActivas());
            cboFiltroUbicacion.DataSource = ubicaciones;
            cboFiltroUbicacion.DisplayMember = "EtiquetaCombo";
            cboFiltroUbicacion.ValueMember = "IdUbicacion";
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            EjecutarConsultaStock();
        }

        private void EjecutarConsultaStock()
        {
            int? idProd = cboFiltroProducto.SelectedItem is Producto p && p.IdProducto > 0 ? p.IdProducto : null;
            int? idUbi = cboFiltroUbicacion.SelectedItem is Ubicacion u && u.IdUbicacion > 0 ? u.IdUbicacion : null;

            _existenciasActuales = _servicioInventario.ConsultarStock(new FiltroStock
            {
                IdProducto = idProd,
                IdUbicacion = idUbi
            });

            dgvExistencias.DataSource = _existenciasActuales.Select(x => new
            {
                Producto = x.NombreProducto,
                Unidad = x.UnidadControl,
                Ubicación = x.CodigoUbicacion,
                Registrada = x.Registrada,
                Habilitada = x.Habilitada
            }).ToList();

            if (_existenciasActuales.Count > 0)
            {
                MostrarGruposDeFila(0);
            }
            else
            {
                dgvGrupos.DataSource = null;
                lblGruposTitulo.Text = "Grupos";
            }
        }

        private void dgvExistencias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvExistencias.CurrentRow != null)
            {
                MostrarGruposDeFila(dgvExistencias.CurrentRow.Index);
            }
        }

        private void MostrarGruposDeFila(int indice)
        {
            if (indice < 0 || indice >= _existenciasActuales.Count)
            {
                return;
            }

            var fila = _existenciasActuales[indice];
            lblGruposTitulo.Text = $"Grupos - {fila.UnidadControl}";

            var grupos = _servicioInventario.ConsultarGrupos(fila.IdProducto, fila.IdUnidadMedida, fila.IdUbicacion);
            dgvGrupos.DataSource = grupos.Select(g => new
            {
                Grupo = g.GrupoLote,
                Recepción = g.Recepcion,
                Vencimiento = g.Vencimiento,
                Verificación = g.Verificacion,
                Cantidad = g.Cantidad,
                Estado = g.CondicionDespacho
            }).ToList();
        }
    }
}

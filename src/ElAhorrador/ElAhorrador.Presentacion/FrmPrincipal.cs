using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Data;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;
using ElAhorrador.Negocio.Seguridad;
using ElAhorrador.Negocio.Servicios;

namespace ElAhorrador.Presentacion
{
    public partial class FrmPrincipal : Form
    {
        private readonly ServicioUsuarios _servicioUsuarios;
        private readonly ServicioCatalogos _servicioCatalogos;
        private readonly ServicioInventario _servicioInventario;

        public FrmPrincipal(ServicioUsuarios servicioUsuarios, ServicioCatalogos servicioCatalogos, ServicioInventario servicioInventario)
        {
            InitializeComponent();
            _servicioUsuarios = servicioUsuarios;
            _servicioCatalogos = servicioCatalogos;
            _servicioInventario = servicioInventario;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            var usuario = SesionActual.UsuarioActivo;
            if (usuario != null)
            {
                lblUsuario.Text = $"{usuario.NombreCompleto}\r\n{usuario.RolDescripcion}";
                lblEncabezado.Text = $"Almacén Central  |  Sesión activa: {usuario.NombreUsuario} ({usuario.RolDescripcion})";
                btnNuevoProducto.Visible = usuario.EsJefe;
            }

            CargarCombosNuevoProducto();
            MostrarVistaInicio();
        }

        private void CargarCombosNuevoProducto()
        {
            cboProdCategoria.DataSource = _servicioCatalogos.ListarCategoriasActivas();
            cboProdCategoria.DisplayMember = "Nombre";
            cboProdCategoria.ValueMember = "IdCategoria";

            cboProdUnidadInicial.DataSource = _servicioCatalogos.ListarUnidadesStockActivas();
            cboProdUnidadInicial.DisplayMember = "EtiquetaCombo";
            cboProdUnidadInicial.ValueMember = "IdUnidadMedida";

            cboProdUbicacionInicial.DataSource = _servicioCatalogos.ListarUbicacionesActivas();
            cboProdUbicacionInicial.DisplayMember = "EtiquetaCombo";
            cboProdUbicacionInicial.ValueMember = "IdUbicacion";

            cboProdClasificacion.SelectedIndex = 0;
            cboProdConservacion.SelectedIndex = 0;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarVistaInicio();
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            MostrarVistaProductos();
        }

        private void btnEntradas_Click(object sender, EventArgs e)
        {
            using var frmEntradas = new FrmEntradas(_servicioInventario, _servicioCatalogos);
            frmEntradas.ShowDialog(this);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            using var frmStock = new FrmStock(_servicioInventario, _servicioCatalogos);
            frmStock.ShowDialog(this);
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            _servicioUsuarios.CerrarSesion();
            Close();
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            CargarProductosEnTabla();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            MostrarVistaNuevoProducto();
        }

        private void btnCancelarProducto_Click(object sender, EventArgs e)
        {
            MostrarVistaProductos();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (cboProdCategoria.SelectedItem is not Categoria cat ||
                cboProdUnidadInicial.SelectedItem is not UnidadControlStock uni ||
                cboProdUbicacionInicial.SelectedItem is not Ubicacion ubi)
            {
                return;
            }

            var datos = new DatosProducto
            {
                Codigo = txtProdCodigo.Text,
                Nombre = txtProdNombre.Text,
                PresentacionFisica = txtProdPresentacion.Text,
                Descripcion = txtProdDescripcion.Text,
                IdCategoria = cat.IdCategoria,
                Clasificacion = cboProdClasificacion.SelectedItem?.ToString() ?? "ALIMENTO",
                ConservacionRequerida = cboProdConservacion.SelectedItem?.ToString() ?? "SECO",
                ControlLote = chkProdLote.Checked,
                ControlVencimiento = chkProdVencimiento.Checked,
                IdUnidadMedidaInicial = uni.IdUnidadMedida,
                IdUbicacionInicial = ubi.IdUbicacion
            };

            var resultado = _servicioCatalogos.RegistrarProducto(datos);
            if (!resultado.Exito)
            {
                MessageBox.Show(resultado.Mensaje, "No se pudo guardar el producto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(resultado.Mensaje, "Operación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtProdCodigo.Clear();
            txtProdNombre.Clear();
            txtProdPresentacion.Clear();
            txtProdDescripcion.Clear();
            MostrarVistaProductos();
        }

        private void MostrarVistaInicio()
        {
            panelVistaInicio.Visible = true;
            panelVistaProductos.Visible = false;
            panelVistaNuevoProducto.Visible = false;
            panelVistaInicio.BringToFront();
        }

        private void MostrarVistaProductos()
        {
            panelVistaProductos.Visible = true;
            panelVistaInicio.Visible = false;
            panelVistaNuevoProducto.Visible = false;
            panelVistaProductos.BringToFront();
            CargarProductosEnTabla();
        }

        private void MostrarVistaNuevoProducto()
        {
            panelVistaNuevoProducto.Visible = true;
            panelVistaProductos.Visible = false;
            panelVistaInicio.Visible = false;
            panelVistaNuevoProducto.BringToFront();
            txtProdCodigo.Focus();
        }

        private void CargarProductosEnTabla()
        {
            var productos = _servicioCatalogos.ConsultarProductos(txtBuscarProducto.Text);

            dgvProductos.DataSource = productos.Select(p => new
            {
                Código = p.Codigo,
                Producto = p.Nombre,
                Categoría = p.NombreCategoria,
                Presentación = p.PresentacionFisica,
                Conservación = p.ConservacionRequerida,
                Estado = p.EstadoTexto
            }).ToList();
        }
    }
}

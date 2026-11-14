using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ElAhorrador.Negocio.Dominio;
using ElAhorrador.Negocio.Intercambio;
using ElAhorrador.Negocio.Servicios;

namespace ElAhorrador.Presentacion
{
    public partial class FrmEntradas : Form
    {
        private readonly ServicioInventario _servicioInventario;
        private readonly ServicioCatalogos _servicioCatalogos;
        private int _numeroConfirmacionActual;

        public FrmEntradas(ServicioInventario servicioInventario, ServicioCatalogos servicioCatalogos)
        {
            InitializeComponent();
            _servicioInventario = servicioInventario;
            _servicioCatalogos = servicioCatalogos;
        }

        private void FrmEntradas_Load(object sender, EventArgs e)
        {
            CargarCatalogos();
            PrepararNuevaConfirmacion();
            cboTipoEntrada.SelectedIndex = 0;
            ActualizarResumenIncidencia();
        }

        private void CargarCatalogos()
        {
            cboProducto.DataSource = _servicioCatalogos.ConsultarProductos();
            cboProducto.DisplayMember = "EtiquetaCombo";
            cboProducto.ValueMember = "IdProducto";

            cboUnidad.DataSource = _servicioCatalogos.ListarUnidadesStockActivas();
            cboUnidad.DisplayMember = "EtiquetaCombo";
            cboUnidad.ValueMember = "IdUnidadMedida";

            cboUbicacion.DataSource = _servicioCatalogos.ListarUbicacionesActivas();
            cboUbicacion.DisplayMember = "EtiquetaCombo";
            cboUbicacion.ValueMember = "IdUbicacion";

            cboLocalOrigen.DataSource = _servicioCatalogos.ListarLocales();
            cboLocalOrigen.DisplayMember = "Nombre";
            cboLocalOrigen.ValueMember = "IdLocal";
        }

        private void PrepararNuevaConfirmacion()
        {
            _numeroConfirmacionActual = _servicioInventario.ObtenerSiguienteConfirmacion();
            txtFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void cboTipoEntrada_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool esDevolucion = cboTipoEntrada.SelectedIndex == 1;
            txtProveedor.Enabled = !esDevolucion;
            cboLocalOrigen.Enabled = esDevolucion;
        }

        private void chkVencimientoComprobado_CheckedChanged(object sender, EventArgs e)
        {
            dtpVencimiento.Enabled = chkVencimientoComprobado.Checked;
        }

        private void Cantidades_ValueChanged(object sender, EventArgs e)
        {
            ActualizarResumenIncidencia();
        }

        private void ActualizarResumenIncidencia()
        {
            var calc = _servicioInventario.PrecalcularDetalle(
                nudEsperada.Value,
                nudRecibida.Value,
                nudAceptada.Value);

            if (calc.ResultadoVerificacion == "CONFORME")
            {
                lblResumenIncidencia.Text = "Verificación física: Conforme (sin diferencias respecto a lo esperado).";
                lblResumenIncidencia.ForeColor = Color.FromArgb(35, 107, 78);
            }
            else
            {
                lblResumenIncidencia.Text = $"Incidencia: faltante de {calc.CantidadFaltante:0.###} unidades; no aceptadas: {calc.CantidadNoAceptada:0.###} unidades.";
                lblResumenIncidencia.ForeColor = Color.FromArgb(180, 85, 20);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cboProducto.SelectedItem is not Producto prod ||
                cboUnidad.SelectedItem is not UnidadControlStock uni ||
                cboUbicacion.SelectedItem is not Ubicacion ubi)
            {
                MessageBox.Show("Seleccione producto, unidad y ubicación.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnConfirmar.Enabled = false;
            try
            {
                var comando = new ComandoEntrada
                {
                    NumeroConfirmacion = _numeroConfirmacionActual,
                    Tipo = cboTipoEntrada.SelectedIndex == 0 ? "COMPRA_PROVEEDOR" : "DEVOLUCION_LOCAL",
                    Proveedor = txtProveedor.Text,
                    IdLocalOrigen = cboTipoEntrada.SelectedIndex == 1 && cboLocalOrigen.SelectedItem is Local loc ? loc.IdLocal : null,
                    Conductor = txtConductor.Text,
                    Placa = txtPlaca.Text,
                    Observaciones = txtObservaciones.Text,
                    IdProducto = prod.IdProducto,
                    IdUnidadMedida = uni.IdUnidadMedida,
                    IdUbicacion = ubi.IdUbicacion,
                    CantidadEsperada = nudEsperada.Value,
                    CantidadRecibida = nudRecibida.Value,
                    CantidadAceptada = nudAceptada.Value,
                    Lote = txtLote.Text,
                    Vencimiento = DateOnly.FromDateTime(dtpVencimiento.Value.Date),
                    VencimientoComprobado = chkVencimientoComprobado.Checked,
                    ObservacionIncidencia = txtObservacionIncidencia.Text
                };

                var resultado = _servicioInventario.RegistrarEntrada(comando);
                if (!resultado.Exito)
                {
                    MessageBox.Show(resultado.Mensaje, "No se pudo registrar la entrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string titulo = comando.CantidadAceptada == 0
                    ? "Recepción no aceptada registrada"
                    : "Operación completada";

                MessageBox.Show(resultado.Mensaje, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                PrepararNuevaConfirmacion();
            }
            finally
            {
                btnConfirmar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

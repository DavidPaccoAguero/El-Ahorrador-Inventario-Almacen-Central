namespace ElAhorrador.Presentacion
{
    partial class FrmEntradas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            panelDatos = new Panel();
            lblTipo = new Label();
            cboTipoEntrada = new ComboBox();
            lblProveedor = new Label();
            txtProveedor = new TextBox();
            lblLocalOrigen = new Label();
            cboLocalOrigen = new ComboBox();
            lblFechaHora = new Label();
            txtFechaHora = new TextBox();
            lblConductor = new Label();
            txtConductor = new TextBox();
            lblPlaca = new Label();
            txtPlaca = new TextBox();
            lblObservaciones = new Label();
            txtObservaciones = new TextBox();
            lblProducto = new Label();
            cboProducto = new ComboBox();
            lblUnidad = new Label();
            cboUnidad = new ComboBox();
            lblUbicacion = new Label();
            cboUbicacion = new ComboBox();
            lblEsperada = new Label();
            nudEsperada = new NumericUpDown();
            lblRecibida = new Label();
            nudRecibida = new NumericUpDown();
            lblAceptada = new Label();
            nudAceptada = new NumericUpDown();
            lblLote = new Label();
            txtLote = new TextBox();
            chkVencimientoComprobado = new CheckBox();
            dtpVencimiento = new DateTimePicker();
            lblObsIncidencia = new Label();
            txtObservacionIncidencia = new TextBox();
            lblResumenIncidencia = new Label();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            panelDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEsperada).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudRecibida).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudAceptada).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblTitulo.Location = new Point(28, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(247, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar entradas";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.FromArgb(90, 105, 95);
            lblSubtitulo.Location = new Point(30, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(106, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Datos del registro";
            // 
            // panelDatos
            // 
            panelDatos.BackColor = Color.White;
            panelDatos.Controls.Add(lblTipo);
            panelDatos.Controls.Add(cboTipoEntrada);
            panelDatos.Controls.Add(lblProveedor);
            panelDatos.Controls.Add(txtProveedor);
            panelDatos.Controls.Add(lblLocalOrigen);
            panelDatos.Controls.Add(cboLocalOrigen);
            panelDatos.Controls.Add(lblFechaHora);
            panelDatos.Controls.Add(txtFechaHora);
            panelDatos.Controls.Add(lblConductor);
            panelDatos.Controls.Add(txtConductor);
            panelDatos.Controls.Add(lblPlaca);
            panelDatos.Controls.Add(txtPlaca);
            panelDatos.Controls.Add(lblObservaciones);
            panelDatos.Controls.Add(txtObservaciones);
            panelDatos.Controls.Add(lblProducto);
            panelDatos.Controls.Add(cboProducto);
            panelDatos.Controls.Add(lblUnidad);
            panelDatos.Controls.Add(cboUnidad);
            panelDatos.Controls.Add(lblUbicacion);
            panelDatos.Controls.Add(cboUbicacion);
            panelDatos.Controls.Add(lblEsperada);
            panelDatos.Controls.Add(nudEsperada);
            panelDatos.Controls.Add(lblRecibida);
            panelDatos.Controls.Add(nudRecibida);
            panelDatos.Controls.Add(lblAceptada);
            panelDatos.Controls.Add(nudAceptada);
            panelDatos.Controls.Add(lblLote);
            panelDatos.Controls.Add(txtLote);
            panelDatos.Controls.Add(chkVencimientoComprobado);
            panelDatos.Controls.Add(dtpVencimiento);
            panelDatos.Controls.Add(lblObsIncidencia);
            panelDatos.Controls.Add(txtObservacionIncidencia);
            panelDatos.Controls.Add(lblResumenIncidencia);
            panelDatos.Location = new Point(28, 82);
            panelDatos.Name = "panelDatos";
            panelDatos.Size = new Size(880, 440);
            panelDatos.TabIndex = 2;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblTipo.ForeColor = Color.FromArgb(90, 105, 95);
            lblTipo.Location = new Point(22, 18);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(96, 17);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de entrada";
            // 
            // cboTipoEntrada
            // 
            cboTipoEntrada.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoEntrada.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboTipoEntrada.FormattingEnabled = true;
            cboTipoEntrada.Items.AddRange(new object[] { "Compra a proveedor", "Devolución de local" });
            cboTipoEntrada.Location = new Point(22, 40);
            cboTipoEntrada.Name = "cboTipoEntrada";
            cboTipoEntrada.Size = new Size(220, 25);
            cboTipoEntrada.TabIndex = 1;
            cboTipoEntrada.SelectedIndexChanged += cboTipoEntrada_SelectedIndexChanged;
            // 
            // lblProveedor
            // 
            lblProveedor.AutoSize = true;
            lblProveedor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProveedor.ForeColor = Color.FromArgb(90, 105, 95);
            lblProveedor.Location = new Point(265, 18);
            lblProveedor.Name = "lblProveedor";
            lblProveedor.Size = new Size(65, 17);
            lblProveedor.TabIndex = 2;
            lblProveedor.Text = "Proveedor";
            // 
            // txtProveedor
            // 
            txtProveedor.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtProveedor.Location = new Point(265, 40);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(210, 25);
            txtProveedor.TabIndex = 3;
            txtProveedor.Text = "Distribuidora Central";
            // 
            // lblLocalOrigen
            // 
            lblLocalOrigen.AutoSize = true;
            lblLocalOrigen.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblLocalOrigen.ForeColor = Color.FromArgb(90, 105, 95);
            lblLocalOrigen.Location = new Point(495, 18);
            lblLocalOrigen.Name = "lblLocalOrigen";
            lblLocalOrigen.Size = new Size(94, 17);
            lblLocalOrigen.TabIndex = 4;
            lblLocalOrigen.Text = "Local de origen";
            // 
            // cboLocalOrigen
            // 
            cboLocalOrigen.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLocalOrigen.Enabled = false;
            cboLocalOrigen.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboLocalOrigen.FormattingEnabled = true;
            cboLocalOrigen.Location = new Point(495, 40);
            cboLocalOrigen.Name = "cboLocalOrigen";
            cboLocalOrigen.Size = new Size(145, 25);
            cboLocalOrigen.TabIndex = 5;
            // 
            // lblFechaHora
            // 
            lblFechaHora.AutoSize = true;
            lblFechaHora.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblFechaHora.ForeColor = Color.FromArgb(90, 105, 95);
            lblFechaHora.Location = new Point(660, 18);
            lblFechaHora.Name = "lblFechaHora";
            lblFechaHora.Size = new Size(79, 17);
            lblFechaHora.TabIndex = 6;
            lblFechaHora.Text = "Fecha y hora";
            // 
            // txtFechaHora
            // 
            txtFechaHora.BackColor = Color.FromArgb(232, 240, 235);
            txtFechaHora.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtFechaHora.Location = new Point(660, 40);
            txtFechaHora.Name = "txtFechaHora";
            txtFechaHora.ReadOnly = true;
            txtFechaHora.Size = new Size(195, 25);
            txtFechaHora.TabIndex = 7;
            txtFechaHora.Text = "07/11/2026 09:15";
            // 
            // lblConductor
            // 
            lblConductor.AutoSize = true;
            lblConductor.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblConductor.ForeColor = Color.FromArgb(90, 105, 95);
            lblConductor.Location = new Point(22, 82);
            lblConductor.Name = "lblConductor";
            lblConductor.Size = new Size(67, 17);
            lblConductor.TabIndex = 8;
            lblConductor.Text = "Conductor";
            // 
            // txtConductor
            // 
            txtConductor.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtConductor.Location = new Point(22, 104);
            txtConductor.Name = "txtConductor";
            txtConductor.Size = new Size(220, 25);
            txtConductor.TabIndex = 9;
            txtConductor.Text = "Luis Ramos";
            // 
            // lblPlaca
            // 
            lblPlaca.AutoSize = true;
            lblPlaca.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblPlaca.ForeColor = Color.FromArgb(90, 105, 95);
            lblPlaca.Location = new Point(265, 82);
            lblPlaca.Name = "lblPlaca";
            lblPlaca.Size = new Size(36, 17);
            lblPlaca.TabIndex = 10;
            lblPlaca.Text = "Placa";
            // 
            // txtPlaca
            // 
            txtPlaca.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtPlaca.Location = new Point(265, 104);
            txtPlaca.Name = "txtPlaca";
            txtPlaca.Size = new Size(150, 25);
            txtPlaca.TabIndex = 11;
            txtPlaca.Text = "V5A-318";
            // 
            // lblObservaciones
            // 
            lblObservaciones.AutoSize = true;
            lblObservaciones.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblObservaciones.ForeColor = Color.FromArgb(90, 105, 95);
            lblObservaciones.Location = new Point(435, 82);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(90, 17);
            lblObservaciones.TabIndex = 12;
            lblObservaciones.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtObservaciones.Location = new Point(435, 104);
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(420, 25);
            txtObservaciones.TabIndex = 13;
            txtObservaciones.Text = "Recepción de mercadería";
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProducto.ForeColor = Color.FromArgb(90, 105, 95);
            lblProducto.Location = new Point(22, 148);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(59, 17);
            lblProducto.TabIndex = 14;
            lblProducto.Text = "Producto";
            // 
            // cboProducto
            // 
            cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboProducto.FormattingEnabled = true;
            cboProducto.Location = new Point(22, 170);
            cboProducto.Name = "cboProducto";
            cboProducto.Size = new Size(320, 25);
            cboProducto.TabIndex = 15;
            // 
            // lblUnidad
            // 
            lblUnidad.AutoSize = true;
            lblUnidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblUnidad.ForeColor = Color.FromArgb(90, 105, 95);
            lblUnidad.Location = new Point(365, 148);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(48, 17);
            lblUnidad.TabIndex = 16;
            lblUnidad.Text = "Unidad";
            // 
            // cboUnidad
            // 
            cboUnidad.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUnidad.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboUnidad.FormattingEnabled = true;
            cboUnidad.Location = new Point(365, 170);
            cboUnidad.Name = "cboUnidad";
            cboUnidad.Size = new Size(190, 25);
            cboUnidad.TabIndex = 17;
            // 
            // lblUbicacion
            // 
            lblUbicacion.AutoSize = true;
            lblUbicacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblUbicacion.ForeColor = Color.FromArgb(90, 105, 95);
            lblUbicacion.Location = new Point(575, 148);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(63, 17);
            lblUbicacion.TabIndex = 18;
            lblUbicacion.Text = "Ubicación";
            // 
            // cboUbicacion
            // 
            cboUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUbicacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboUbicacion.FormattingEnabled = true;
            cboUbicacion.Location = new Point(575, 170);
            cboUbicacion.Name = "cboUbicacion";
            cboUbicacion.Size = new Size(280, 25);
            cboUbicacion.TabIndex = 19;
            // 
            // lblEsperada
            // 
            lblEsperada.AutoSize = true;
            lblEsperada.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblEsperada.ForeColor = Color.FromArgb(90, 105, 95);
            lblEsperada.Location = new Point(22, 215);
            lblEsperada.Name = "lblEsperada";
            lblEsperada.Size = new Size(60, 17);
            lblEsperada.TabIndex = 20;
            lblEsperada.Text = "Esperada";
            // 
            // nudEsperada
            // 
            nudEsperada.DecimalPlaces = 3;
            nudEsperada.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            nudEsperada.Location = new Point(22, 237);
            nudEsperada.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudEsperada.Name = "nudEsperada";
            nudEsperada.Size = new Size(150, 25);
            nudEsperada.TabIndex = 21;
            nudEsperada.Value = new decimal(new int[] { 8, 0, 0, 0 });
            nudEsperada.ValueChanged += Cantidades_ValueChanged;
            // 
            // lblRecibida
            // 
            lblRecibida.AutoSize = true;
            lblRecibida.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblRecibida.ForeColor = Color.FromArgb(90, 105, 95);
            lblRecibida.Location = new Point(195, 215);
            lblRecibida.Name = "lblRecibida";
            lblRecibida.Size = new Size(56, 17);
            lblRecibida.TabIndex = 22;
            lblRecibida.Text = "Recibida";
            // 
            // nudRecibida
            // 
            nudRecibida.DecimalPlaces = 3;
            nudRecibida.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            nudRecibida.Location = new Point(195, 237);
            nudRecibida.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudRecibida.Name = "nudRecibida";
            nudRecibida.Size = new Size(150, 25);
            nudRecibida.TabIndex = 23;
            nudRecibida.Value = new decimal(new int[] { 6, 0, 0, 0 });
            nudRecibida.ValueChanged += Cantidades_ValueChanged;
            // 
            // lblAceptada
            // 
            lblAceptada.AutoSize = true;
            lblAceptada.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblAceptada.ForeColor = Color.FromArgb(90, 105, 95);
            lblAceptada.Location = new Point(368, 215);
            lblAceptada.Name = "lblAceptada";
            lblAceptada.Size = new Size(61, 17);
            lblAceptada.TabIndex = 24;
            lblAceptada.Text = "Aceptada";
            // 
            // nudAceptada
            // 
            nudAceptada.DecimalPlaces = 3;
            nudAceptada.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            nudAceptada.Location = new Point(368, 237);
            nudAceptada.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            nudAceptada.Name = "nudAceptada";
            nudAceptada.Size = new Size(150, 25);
            nudAceptada.TabIndex = 25;
            nudAceptada.Value = new decimal(new int[] { 6, 0, 0, 0 });
            nudAceptada.ValueChanged += Cantidades_ValueChanged;
            // 
            // lblLote
            // 
            lblLote.AutoSize = true;
            lblLote.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblLote.ForeColor = Color.FromArgb(90, 105, 95);
            lblLote.Location = new Point(540, 215);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(31, 17);
            lblLote.TabIndex = 26;
            lblLote.Text = "Lote";
            // 
            // txtLote
            // 
            txtLote.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtLote.Location = new Point(540, 237);
            txtLote.Name = "txtLote";
            txtLote.Size = new Size(315, 25);
            txtLote.TabIndex = 27;
            txtLote.Text = "L-253";
            // 
            // chkVencimientoComprobado
            // 
            chkVencimientoComprobado.AutoSize = true;
            chkVencimientoComprobado.Checked = true;
            chkVencimientoComprobado.CheckState = CheckState.Checked;
            chkVencimientoComprobado.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkVencimientoComprobado.ForeColor = Color.FromArgb(90, 105, 95);
            chkVencimientoComprobado.Location = new Point(22, 282);
            chkVencimientoComprobado.Name = "chkVencimientoComprobado";
            chkVencimientoComprobado.Size = new Size(178, 21);
            chkVencimientoComprobado.TabIndex = 28;
            chkVencimientoComprobado.Text = "Vencimiento comprobado";
            chkVencimientoComprobado.UseVisualStyleBackColor = true;
            chkVencimientoComprobado.CheckedChanged += chkVencimientoComprobado_CheckedChanged;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.Location = new Point(22, 306);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.Size = new Size(220, 25);
            dtpVencimiento.TabIndex = 29;
            dtpVencimiento.Value = new DateTime(2027, 3, 15, 0, 0, 0, 0);
            // 
            // lblObsIncidencia
            // 
            lblObsIncidencia.AutoSize = true;
            lblObsIncidencia.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblObsIncidencia.ForeColor = Color.FromArgb(90, 105, 95);
            lblObsIncidencia.Location = new Point(265, 282);
            lblObsIncidencia.Name = "lblObsIncidencia";
            lblObsIncidencia.Size = new Size(172, 17);
            lblObsIncidencia.TabIndex = 30;
            lblObsIncidencia.Text = "Observación de la recepción";
            // 
            // txtObservacionIncidencia
            // 
            txtObservacionIncidencia.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtObservacionIncidencia.Location = new Point(265, 306);
            txtObservacionIncidencia.Name = "txtObservacionIncidencia";
            txtObservacionIncidencia.Size = new Size(590, 25);
            txtObservacionIncidencia.TabIndex = 31;
            txtObservacionIncidencia.Text = "Diferencia respecto de la cantidad esperada";
            // 
            // lblResumenIncidencia
            // 
            lblResumenIncidencia.AutoSize = true;
            lblResumenIncidencia.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            lblResumenIncidencia.ForeColor = Color.FromArgb(180, 85, 20);
            lblResumenIncidencia.Location = new Point(22, 360);
            lblResumenIncidencia.Name = "lblResumenIncidencia";
            lblResumenIncidencia.Size = new Size(222, 19);
            lblResumenIncidencia.TabIndex = 32;
            lblResumenIncidencia.Text = "Incidencia: faltante de 2 unidades.";
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(35, 107, 78);
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(28, 538);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(160, 42);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = false;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.White;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCancelar.ForeColor = Color.FromArgb(60, 75, 68);
            btnCancelar.Location = new Point(202, 538);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 42);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // FrmEntradas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 243, 238);
            ClientSize = new Size(938, 604);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(panelDatos);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmEntradas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "El Ahorrador - Gestión de inventarios y control de almacén";
            Load += FrmEntradas_Load;
            panelDatos.ResumeLayout(false);
            panelDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEsperada).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudRecibida).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAceptada).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Panel panelDatos;
        private Label lblTipo;
        private ComboBox cboTipoEntrada;
        private Label lblProveedor;
        private TextBox txtProveedor;
        private Label lblLocalOrigen;
        private ComboBox cboLocalOrigen;
        private Label lblFechaHora;
        private TextBox txtFechaHora;
        private Label lblConductor;
        private TextBox txtConductor;
        private Label lblPlaca;
        private TextBox txtPlaca;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Label lblProducto;
        private ComboBox cboProducto;
        private Label lblUnidad;
        private ComboBox cboUnidad;
        private Label lblUbicacion;
        private ComboBox cboUbicacion;
        private Label lblEsperada;
        private NumericUpDown nudEsperada;
        private Label lblRecibida;
        private NumericUpDown nudRecibida;
        private Label lblAceptada;
        private NumericUpDown nudAceptada;
        private Label lblLote;
        private TextBox txtLote;
        private CheckBox chkVencimientoComprobado;
        private DateTimePicker dtpVencimiento;
        private Label lblObsIncidencia;
        private TextBox txtObservacionIncidencia;
        private Label lblResumenIncidencia;
        private Button btnConfirmar;
        private Button btnCancelar;
    }
}

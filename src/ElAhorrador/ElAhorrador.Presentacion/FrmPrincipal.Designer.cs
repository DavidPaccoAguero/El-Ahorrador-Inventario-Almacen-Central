namespace ElAhorrador.Presentacion
{
    partial class FrmPrincipal
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
            panelMenu = new Panel();
            lblLogo = new Label();
            btnInicio = new Button();
            btnEntradas = new Button();
            btnStock = new Button();
            btnCatalogos = new Button();
            lblUsuario = new Label();
            btnCerrarSesion = new Button();
            panelSuperior = new Panel();
            lblEncabezado = new Label();
            panelContenido = new Panel();
            panelVistaNuevoProducto = new Panel();
            lblNuevoTitulo = new Label();
            lblProdCodigo = new Label();
            txtProdCodigo = new TextBox();
            lblProdNombre = new Label();
            txtProdNombre = new TextBox();
            lblProdCategoria = new Label();
            cboProdCategoria = new ComboBox();
            lblProdPresentacion = new Label();
            txtProdPresentacion = new TextBox();
            lblProdClasificacion = new Label();
            cboProdClasificacion = new ComboBox();
            lblProdConservacion = new Label();
            cboProdConservacion = new ComboBox();
            lblProdDescripcion = new Label();
            txtProdDescripcion = new TextBox();
            lblProdUnidad = new Label();
            cboProdUnidadInicial = new ComboBox();
            lblProdUbicacion = new Label();
            cboProdUbicacionInicial = new ComboBox();
            chkProdLote = new CheckBox();
            chkProdVencimiento = new CheckBox();
            btnGuardarProducto = new Button();
            btnCancelarProducto = new Button();
            panelVistaProductos = new Panel();
            btnNuevoProducto = new Button();
            lblProdTitulo = new Label();
            lblBuscar = new Label();
            txtBuscarProducto = new TextBox();
            dgvProductos = new DataGridView();
            panelVistaInicio = new Panel();
            lblInicioTitulo = new Label();
            lblInicioSub = new Label();
            btnIrEntradas = new Button();
            btnIrStock = new Button();
            btnIrProductos = new Button();
            panelMenu.SuspendLayout();
            panelSuperior.SuspendLayout();
            panelContenido.SuspendLayout();
            panelVistaNuevoProducto.SuspendLayout();
            panelVistaProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelVistaInicio.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(24, 77, 59);
            panelMenu.Controls.Add(lblLogo);
            panelMenu.Controls.Add(btnInicio);
            panelMenu.Controls.Add(btnEntradas);
            panelMenu.Controls.Add(btnStock);
            panelMenu.Controls.Add(btnCatalogos);
            panelMenu.Controls.Add(lblUsuario);
            panelMenu.Controls.Add(btnCerrarSesion);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(230, 681);
            panelMenu.TabIndex = 0;
            // 
            // lblLogo
            // 
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(20, 22);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(156, 40);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "EL AHORRADOR\r\nALMACÉN CENTRAL";
            // 
            // btnInicio
            // 
            btnInicio.BackColor = Color.FromArgb(35, 107, 78);
            btnInicio.Cursor = Cursors.Hand;
            btnInicio.FlatAppearance.BorderSize = 0;
            btnInicio.FlatStyle = FlatStyle.Flat;
            btnInicio.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnInicio.ForeColor = Color.White;
            btnInicio.Location = new Point(15, 95);
            btnInicio.Name = "btnInicio";
            btnInicio.Size = new Size(200, 40);
            btnInicio.TabIndex = 1;
            btnInicio.Text = "  Inicio";
            btnInicio.TextAlign = ContentAlignment.MiddleLeft;
            btnInicio.UseVisualStyleBackColor = false;
            btnInicio.Click += btnInicio_Click;
            // 
            // btnEntradas
            // 
            btnEntradas.BackColor = Color.FromArgb(35, 107, 78);
            btnEntradas.Cursor = Cursors.Hand;
            btnEntradas.FlatAppearance.BorderSize = 0;
            btnEntradas.FlatStyle = FlatStyle.Flat;
            btnEntradas.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnEntradas.ForeColor = Color.White;
            btnEntradas.Location = new Point(15, 145);
            btnEntradas.Name = "btnEntradas";
            btnEntradas.Size = new Size(200, 40);
            btnEntradas.TabIndex = 2;
            btnEntradas.Text = "  Entradas";
            btnEntradas.TextAlign = ContentAlignment.MiddleLeft;
            btnEntradas.UseVisualStyleBackColor = false;
            btnEntradas.Click += btnEntradas_Click;
            // 
            // btnStock
            // 
            btnStock.BackColor = Color.FromArgb(35, 107, 78);
            btnStock.Cursor = Cursors.Hand;
            btnStock.FlatAppearance.BorderSize = 0;
            btnStock.FlatStyle = FlatStyle.Flat;
            btnStock.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnStock.ForeColor = Color.White;
            btnStock.Location = new Point(15, 195);
            btnStock.Name = "btnStock";
            btnStock.Size = new Size(200, 40);
            btnStock.TabIndex = 3;
            btnStock.Text = "  Stock";
            btnStock.TextAlign = ContentAlignment.MiddleLeft;
            btnStock.UseVisualStyleBackColor = false;
            btnStock.Click += btnStock_Click;
            // 
            // btnCatalogos
            // 
            btnCatalogos.BackColor = Color.FromArgb(35, 107, 78);
            btnCatalogos.Cursor = Cursors.Hand;
            btnCatalogos.FlatAppearance.BorderSize = 0;
            btnCatalogos.FlatStyle = FlatStyle.Flat;
            btnCatalogos.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCatalogos.ForeColor = Color.White;
            btnCatalogos.Location = new Point(15, 245);
            btnCatalogos.Name = "btnCatalogos";
            btnCatalogos.Size = new Size(200, 40);
            btnCatalogos.TabIndex = 4;
            btnCatalogos.Text = "  Catálogos";
            btnCatalogos.TextAlign = ContentAlignment.MiddleLeft;
            btnCatalogos.UseVisualStyleBackColor = false;
            btnCatalogos.Click += btnCatalogos_Click;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblUsuario.ForeColor = Color.FromArgb(215, 230, 222);
            lblUsuario.Location = new Point(20, 565);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(102, 34);
            lblUsuario.TabIndex = 5;
            lblUsuario.Text = "David Pacco\r\nJefe de Almacén";
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(35, 107, 78);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(20, 620);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(190, 36);
            btnCerrarSesion.TabIndex = 6;
            btnCerrarSesion.Text = "Cerrar sesión";
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.White;
            panelSuperior.Controls.Add(lblEncabezado);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(230, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(934, 52);
            panelSuperior.TabIndex = 1;
            // 
            // lblEncabezado
            // 
            lblEncabezado.AutoSize = true;
            lblEncabezado.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            lblEncabezado.ForeColor = Color.FromArgb(50, 65, 58);
            lblEncabezado.Location = new Point(25, 15);
            lblEncabezado.Name = "lblEncabezado";
            lblEncabezado.Size = new Size(392, 19);
            lblEncabezado.TabIndex = 0;
            lblEncabezado.Text = "Almacén Central  |  Sesión activa: d.pacco (Jefe de Almacén)";
            // 
            // panelContenido
            // 
            panelContenido.Controls.Add(panelVistaNuevoProducto);
            panelContenido.Controls.Add(panelVistaProductos);
            panelContenido.Controls.Add(panelVistaInicio);
            panelContenido.Dock = DockStyle.Fill;
            panelContenido.Location = new Point(230, 52);
            panelContenido.Name = "panelContenido";
            panelContenido.Padding = new Padding(25);
            panelContenido.Size = new Size(934, 629);
            panelContenido.TabIndex = 2;
            // 
            // panelVistaNuevoProducto
            // 
            panelVistaNuevoProducto.Controls.Add(lblNuevoTitulo);
            panelVistaNuevoProducto.Controls.Add(lblProdCodigo);
            panelVistaNuevoProducto.Controls.Add(txtProdCodigo);
            panelVistaNuevoProducto.Controls.Add(lblProdNombre);
            panelVistaNuevoProducto.Controls.Add(txtProdNombre);
            panelVistaNuevoProducto.Controls.Add(lblProdCategoria);
            panelVistaNuevoProducto.Controls.Add(cboProdCategoria);
            panelVistaNuevoProducto.Controls.Add(lblProdPresentacion);
            panelVistaNuevoProducto.Controls.Add(txtProdPresentacion);
            panelVistaNuevoProducto.Controls.Add(lblProdClasificacion);
            panelVistaNuevoProducto.Controls.Add(cboProdClasificacion);
            panelVistaNuevoProducto.Controls.Add(lblProdConservacion);
            panelVistaNuevoProducto.Controls.Add(cboProdConservacion);
            panelVistaNuevoProducto.Controls.Add(lblProdDescripcion);
            panelVistaNuevoProducto.Controls.Add(txtProdDescripcion);
            panelVistaNuevoProducto.Controls.Add(lblProdUnidad);
            panelVistaNuevoProducto.Controls.Add(cboProdUnidadInicial);
            panelVistaNuevoProducto.Controls.Add(lblProdUbicacion);
            panelVistaNuevoProducto.Controls.Add(cboProdUbicacionInicial);
            panelVistaNuevoProducto.Controls.Add(chkProdLote);
            panelVistaNuevoProducto.Controls.Add(chkProdVencimiento);
            panelVistaNuevoProducto.Controls.Add(btnGuardarProducto);
            panelVistaNuevoProducto.Controls.Add(btnCancelarProducto);
            panelVistaNuevoProducto.Dock = DockStyle.Fill;
            panelVistaNuevoProducto.Location = new Point(25, 25);
            panelVistaNuevoProducto.Name = "panelVistaNuevoProducto";
            panelVistaNuevoProducto.Size = new Size(884, 579);
            panelVistaNuevoProducto.TabIndex = 2;
            panelVistaNuevoProducto.Visible = false;
            // 
            // lblNuevoTitulo
            // 
            lblNuevoTitulo.AutoSize = true;
            lblNuevoTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblNuevoTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblNuevoTitulo.Location = new Point(10, 10);
            lblNuevoTitulo.Name = "lblNuevoTitulo";
            lblNuevoTitulo.Size = new Size(251, 37);
            lblNuevoTitulo.TabIndex = 0;
            lblNuevoTitulo.Text = "Agregar producto";
            // 
            // lblProdCodigo
            // 
            lblProdCodigo.AutoSize = true;
            lblProdCodigo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdCodigo.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdCodigo.Location = new Point(14, 72);
            lblProdCodigo.Name = "lblProdCodigo";
            lblProdCodigo.Size = new Size(49, 17);
            lblProdCodigo.TabIndex = 1;
            lblProdCodigo.Text = "Código";
            // 
            // txtProdCodigo
            // 
            txtProdCodigo.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtProdCodigo.Location = new Point(14, 94);
            txtProdCodigo.Name = "txtProdCodigo";
            txtProdCodigo.Size = new Size(250, 25);
            txtProdCodigo.TabIndex = 2;
            // 
            // lblProdNombre
            // 
            lblProdNombre.AutoSize = true;
            lblProdNombre.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdNombre.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdNombre.Location = new Point(290, 72);
            lblProdNombre.Name = "lblProdNombre";
            lblProdNombre.Size = new Size(56, 17);
            lblProdNombre.TabIndex = 3;
            lblProdNombre.Text = "Nombre";
            // 
            // txtProdNombre
            // 
            txtProdNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtProdNombre.Location = new Point(290, 94);
            txtProdNombre.Name = "txtProdNombre";
            txtProdNombre.Size = new Size(280, 25);
            txtProdNombre.TabIndex = 4;
            // 
            // lblProdCategoria
            // 
            lblProdCategoria.AutoSize = true;
            lblProdCategoria.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdCategoria.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdCategoria.Location = new Point(595, 72);
            lblProdCategoria.Name = "lblProdCategoria";
            lblProdCategoria.Size = new Size(63, 17);
            lblProdCategoria.TabIndex = 5;
            lblProdCategoria.Text = "Categoría";
            // 
            // cboProdCategoria
            // 
            cboProdCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdCategoria.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboProdCategoria.FormattingEnabled = true;
            cboProdCategoria.Location = new Point(595, 94);
            cboProdCategoria.Name = "cboProdCategoria";
            cboProdCategoria.Size = new Size(250, 25);
            cboProdCategoria.TabIndex = 6;
            // 
            // lblProdPresentacion
            // 
            lblProdPresentacion.AutoSize = true;
            lblProdPresentacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdPresentacion.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdPresentacion.Location = new Point(14, 142);
            lblProdPresentacion.Name = "lblProdPresentacion";
            lblProdPresentacion.Size = new Size(114, 17);
            lblProdPresentacion.TabIndex = 7;
            lblProdPresentacion.Text = "Presentación física";
            // 
            // txtProdPresentacion
            // 
            txtProdPresentacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtProdPresentacion.Location = new Point(14, 164);
            txtProdPresentacion.Name = "txtProdPresentacion";
            txtProdPresentacion.Size = new Size(250, 25);
            txtProdPresentacion.TabIndex = 8;
            // 
            // lblProdClasificacion
            // 
            lblProdClasificacion.AutoSize = true;
            lblProdClasificacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdClasificacion.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdClasificacion.Location = new Point(290, 142);
            lblProdClasificacion.Name = "lblProdClasificacion";
            lblProdClasificacion.Size = new Size(80, 17);
            lblProdClasificacion.TabIndex = 9;
            lblProdClasificacion.Text = "Clasificación";
            // 
            // cboProdClasificacion
            // 
            cboProdClasificacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdClasificacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboProdClasificacion.FormattingEnabled = true;
            cboProdClasificacion.Items.AddRange(new object[] { "ALIMENTO", "CARNE", "HIGIENE_PERSONAL", "LIMPIEZA_HOGAR" });
            cboProdClasificacion.Location = new Point(290, 164);
            cboProdClasificacion.Name = "cboProdClasificacion";
            cboProdClasificacion.Size = new Size(280, 25);
            cboProdClasificacion.TabIndex = 10;
            // 
            // lblProdConservacion
            // 
            lblProdConservacion.AutoSize = true;
            lblProdConservacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdConservacion.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdConservacion.Location = new Point(595, 142);
            lblProdConservacion.Name = "lblProdConservacion";
            lblProdConservacion.Size = new Size(86, 17);
            lblProdConservacion.TabIndex = 11;
            lblProdConservacion.Text = "Conservación";
            // 
            // cboProdConservacion
            // 
            cboProdConservacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdConservacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboProdConservacion.FormattingEnabled = true;
            cboProdConservacion.Items.AddRange(new object[] { "SECO", "REFRIGERADO", "CONGELADO" });
            cboProdConservacion.Location = new Point(595, 164);
            cboProdConservacion.Name = "cboProdConservacion";
            cboProdConservacion.Size = new Size(250, 25);
            cboProdConservacion.TabIndex = 12;
            // 
            // lblProdDescripcion
            // 
            lblProdDescripcion.AutoSize = true;
            lblProdDescripcion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdDescripcion.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdDescripcion.Location = new Point(14, 212);
            lblProdDescripcion.Name = "lblProdDescripcion";
            lblProdDescripcion.Size = new Size(75, 17);
            lblProdDescripcion.TabIndex = 13;
            lblProdDescripcion.Text = "Descripción";
            // 
            // txtProdDescripcion
            // 
            txtProdDescripcion.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtProdDescripcion.Location = new Point(14, 234);
            txtProdDescripcion.Name = "txtProdDescripcion";
            txtProdDescripcion.Size = new Size(556, 25);
            txtProdDescripcion.TabIndex = 14;
            // 
            // lblProdUnidad
            // 
            lblProdUnidad.AutoSize = true;
            lblProdUnidad.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdUnidad.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdUnidad.Location = new Point(14, 282);
            lblProdUnidad.Name = "lblProdUnidad";
            lblProdUnidad.Size = new Size(105, 17);
            lblProdUnidad.TabIndex = 15;
            lblProdUnidad.Text = "Unidad asociada";
            // 
            // cboProdUnidadInicial
            // 
            cboProdUnidadInicial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdUnidadInicial.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboProdUnidadInicial.FormattingEnabled = true;
            cboProdUnidadInicial.Location = new Point(14, 304);
            cboProdUnidadInicial.Name = "cboProdUnidadInicial";
            cboProdUnidadInicial.Size = new Size(250, 25);
            cboProdUnidadInicial.TabIndex = 16;
            // 
            // lblProdUbicacion
            // 
            lblProdUbicacion.AutoSize = true;
            lblProdUbicacion.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblProdUbicacion.ForeColor = Color.FromArgb(80, 95, 85);
            lblProdUbicacion.Location = new Point(290, 282);
            lblProdUbicacion.Name = "lblProdUbicacion";
            lblProdUbicacion.Size = new Size(119, 17);
            lblProdUbicacion.TabIndex = 17;
            lblProdUbicacion.Text = "Ubicación asociada";
            // 
            // cboProdUbicacionInicial
            // 
            cboProdUbicacionInicial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProdUbicacionInicial.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboProdUbicacionInicial.FormattingEnabled = true;
            cboProdUbicacionInicial.Location = new Point(290, 304);
            cboProdUbicacionInicial.Name = "cboProdUbicacionInicial";
            cboProdUbicacionInicial.Size = new Size(280, 25);
            cboProdUbicacionInicial.TabIndex = 18;
            // 
            // chkProdLote
            // 
            chkProdLote.AutoSize = true;
            chkProdLote.Checked = true;
            chkProdLote.CheckState = CheckState.Checked;
            chkProdLote.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkProdLote.ForeColor = Color.FromArgb(80, 95, 85);
            chkProdLote.Location = new Point(595, 236);
            chkProdLote.Name = "chkProdLote";
            chkProdLote.Size = new Size(114, 21);
            chkProdLote.TabIndex = 19;
            chkProdLote.Text = "Control de lote";
            chkProdLote.UseVisualStyleBackColor = true;
            // 
            // chkProdVencimiento
            // 
            chkProdVencimiento.AutoSize = true;
            chkProdVencimiento.Checked = true;
            chkProdVencimiento.CheckState = CheckState.Checked;
            chkProdVencimiento.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            chkProdVencimiento.ForeColor = Color.FromArgb(80, 95, 85);
            chkProdVencimiento.Location = new Point(595, 306);
            chkProdVencimiento.Name = "chkProdVencimiento";
            chkProdVencimiento.Size = new Size(162, 21);
            chkProdVencimiento.TabIndex = 20;
            chkProdVencimiento.Text = "Control de vencimiento";
            chkProdVencimiento.UseVisualStyleBackColor = true;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.BackColor = Color.FromArgb(35, 107, 78);
            btnGuardarProducto.Cursor = Cursors.Hand;
            btnGuardarProducto.FlatAppearance.BorderSize = 0;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(14, 375);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(150, 40);
            btnGuardarProducto.TabIndex = 21;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            btnGuardarProducto.Click += btnGuardarProducto_Click;
            // 
            // btnCancelarProducto
            // 
            btnCancelarProducto.BackColor = Color.White;
            btnCancelarProducto.Cursor = Cursors.Hand;
            btnCancelarProducto.FlatStyle = FlatStyle.Flat;
            btnCancelarProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btnCancelarProducto.ForeColor = Color.FromArgb(60, 75, 68);
            btnCancelarProducto.Location = new Point(180, 375);
            btnCancelarProducto.Name = "btnCancelarProducto";
            btnCancelarProducto.Size = new Size(140, 40);
            btnCancelarProducto.TabIndex = 22;
            btnCancelarProducto.Text = "Cancelar";
            btnCancelarProducto.UseVisualStyleBackColor = false;
            btnCancelarProducto.Click += btnCancelarProducto_Click;
            // 
            // panelVistaProductos
            // 
            panelVistaProductos.Controls.Add(btnNuevoProducto);
            panelVistaProductos.Controls.Add(lblProdTitulo);
            panelVistaProductos.Controls.Add(lblBuscar);
            panelVistaProductos.Controls.Add(txtBuscarProducto);
            panelVistaProductos.Controls.Add(dgvProductos);
            panelVistaProductos.Dock = DockStyle.Fill;
            panelVistaProductos.Location = new Point(25, 25);
            panelVistaProductos.Name = "panelVistaProductos";
            panelVistaProductos.Size = new Size(884, 579);
            panelVistaProductos.TabIndex = 0;
            // 
            // btnNuevoProducto
            // 
            btnNuevoProducto.BackColor = Color.FromArgb(35, 107, 78);
            btnNuevoProducto.Cursor = Cursors.Hand;
            btnNuevoProducto.FlatAppearance.BorderSize = 0;
            btnNuevoProducto.FlatStyle = FlatStyle.Flat;
            btnNuevoProducto.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnNuevoProducto.ForeColor = Color.White;
            btnNuevoProducto.Location = new Point(710, 78);
            btnNuevoProducto.Name = "btnNuevoProducto";
            btnNuevoProducto.Size = new Size(160, 36);
            btnNuevoProducto.TabIndex = 4;
            btnNuevoProducto.Text = "+ Agregar";
            btnNuevoProducto.UseVisualStyleBackColor = false;
            btnNuevoProducto.Click += btnNuevoProducto_Click;
            // 
            // lblProdTitulo
            // 
            lblProdTitulo.AutoSize = true;
            lblProdTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblProdTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblProdTitulo.Location = new Point(10, 10);
            lblProdTitulo.Name = "lblProdTitulo";
            lblProdTitulo.Size = new Size(277, 37);
            lblProdTitulo.TabIndex = 0;
            lblProdTitulo.Text = "Gestionar productos";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblBuscar.ForeColor = Color.FromArgb(80, 95, 85);
            lblBuscar.Location = new Point(10, 62);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(166, 17);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar por código o nombre:";
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
            txtBuscarProducto.Location = new Point(10, 85);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(340, 26);
            txtBuscarProducto.TabIndex = 2;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.White;
            dgvProductos.BorderStyle = BorderStyle.None;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvProductos.Location = new Point(10, 130);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(860, 420);
            dgvProductos.TabIndex = 3;
            // 
            // panelVistaInicio
            // 
            panelVistaInicio.Controls.Add(lblInicioTitulo);
            panelVistaInicio.Controls.Add(lblInicioSub);
            panelVistaInicio.Controls.Add(btnIrEntradas);
            panelVistaInicio.Controls.Add(btnIrStock);
            panelVistaInicio.Controls.Add(btnIrProductos);
            panelVistaInicio.Dock = DockStyle.Fill;
            panelVistaInicio.Location = new Point(25, 25);
            panelVistaInicio.Name = "panelVistaInicio";
            panelVistaInicio.Size = new Size(884, 579);
            panelVistaInicio.TabIndex = 1;
            // 
            // lblInicioTitulo
            // 
            lblInicioTitulo.AutoSize = true;
            lblInicioTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblInicioTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblInicioTitulo.Location = new Point(10, 15);
            lblInicioTitulo.Name = "lblInicioTitulo";
            lblInicioTitulo.Size = new Size(86, 37);
            lblInicioTitulo.TabIndex = 0;
            lblInicioTitulo.Text = "Inicio";
            // 
            // lblInicioSub
            // 
            lblInicioSub.AutoSize = true;
            lblInicioSub.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblInicioSub.ForeColor = Color.FromArgb(90, 105, 95);
            lblInicioSub.Location = new Point(10, 58);
            lblInicioSub.Name = "lblInicioSub";
            lblInicioSub.Size = new Size(181, 20);
            lblInicioSub.TabIndex = 1;
            lblInicioSub.Text = "Selecciona una operación";
            // 
            // btnIrEntradas
            // 
            btnIrEntradas.BackColor = Color.FromArgb(35, 107, 78);
            btnIrEntradas.Cursor = Cursors.Hand;
            btnIrEntradas.FlatAppearance.BorderSize = 0;
            btnIrEntradas.FlatStyle = FlatStyle.Flat;
            btnIrEntradas.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIrEntradas.ForeColor = Color.White;
            btnIrEntradas.Location = new Point(10, 105);
            btnIrEntradas.Name = "btnIrEntradas";
            btnIrEntradas.Size = new Size(240, 48);
            btnIrEntradas.TabIndex = 2;
            btnIrEntradas.Text = "Registrar entrada";
            btnIrEntradas.UseVisualStyleBackColor = false;
            btnIrEntradas.Click += btnEntradas_Click;
            // 
            // btnIrStock
            // 
            btnIrStock.BackColor = Color.FromArgb(35, 107, 78);
            btnIrStock.Cursor = Cursors.Hand;
            btnIrStock.FlatAppearance.BorderSize = 0;
            btnIrStock.FlatStyle = FlatStyle.Flat;
            btnIrStock.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIrStock.ForeColor = Color.White;
            btnIrStock.Location = new Point(270, 105);
            btnIrStock.Name = "btnIrStock";
            btnIrStock.Size = new Size(240, 48);
            btnIrStock.TabIndex = 3;
            btnIrStock.Text = "Consultar stock";
            btnIrStock.UseVisualStyleBackColor = false;
            btnIrStock.Click += btnStock_Click;
            // 
            // btnIrProductos
            // 
            btnIrProductos.BackColor = Color.FromArgb(35, 107, 78);
            btnIrProductos.Cursor = Cursors.Hand;
            btnIrProductos.FlatAppearance.BorderSize = 0;
            btnIrProductos.FlatStyle = FlatStyle.Flat;
            btnIrProductos.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            btnIrProductos.ForeColor = Color.White;
            btnIrProductos.Location = new Point(530, 105);
            btnIrProductos.Name = "btnIrProductos";
            btnIrProductos.Size = new Size(240, 48);
            btnIrProductos.TabIndex = 4;
            btnIrProductos.Text = "Gestionar productos";
            btnIrProductos.UseVisualStyleBackColor = false;
            btnIrProductos.Click += btnCatalogos_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 243, 238);
            ClientSize = new Size(1164, 681);
            Controls.Add(panelContenido);
            Controls.Add(panelSuperior);
            Controls.Add(panelMenu);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "El Ahorrador - Gestión de inventarios y control de almacén";
            Load += FrmPrincipal_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            panelContenido.ResumeLayout(false);
            panelVistaNuevoProducto.ResumeLayout(false);
            panelVistaNuevoProducto.PerformLayout();
            panelVistaProductos.ResumeLayout(false);
            panelVistaProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelVistaInicio.ResumeLayout(false);
            panelVistaInicio.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Label lblLogo;
        private Button btnInicio;
        private Button btnEntradas;
        private Button btnStock;
        private Button btnCatalogos;
        private Label lblUsuario;
        private Button btnCerrarSesion;
        private Panel panelSuperior;
        private Label lblEncabezado;
        private Panel panelContenido;
        private Panel panelVistaNuevoProducto;
        private Label lblNuevoTitulo;
        private Label lblProdCodigo;
        private TextBox txtProdCodigo;
        private Label lblProdNombre;
        private TextBox txtProdNombre;
        private Label lblProdCategoria;
        private ComboBox cboProdCategoria;
        private Label lblProdPresentacion;
        private TextBox txtProdPresentacion;
        private Label lblProdClasificacion;
        private ComboBox cboProdClasificacion;
        private Label lblProdConservacion;
        private ComboBox cboProdConservacion;
        private Label lblProdDescripcion;
        private TextBox txtProdDescripcion;
        private Label lblProdUnidad;
        private ComboBox cboProdUnidadInicial;
        private Label lblProdUbicacion;
        private ComboBox cboProdUbicacionInicial;
        private CheckBox chkProdLote;
        private CheckBox chkProdVencimiento;
        private Button btnGuardarProducto;
        private Button btnCancelarProducto;
        private Panel panelVistaProductos;
        private Button btnNuevoProducto;
        private Label lblProdTitulo;
        private Label lblBuscar;
        private TextBox txtBuscarProducto;
        private DataGridView dgvProductos;
        private Panel panelVistaInicio;
        private Label lblInicioTitulo;
        private Label lblInicioSub;
        private Button btnIrEntradas;
        private Button btnIrStock;
        private Button btnIrProductos;
    }
}

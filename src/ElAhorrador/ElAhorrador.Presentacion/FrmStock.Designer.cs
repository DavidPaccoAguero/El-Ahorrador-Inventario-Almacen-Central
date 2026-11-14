namespace ElAhorrador.Presentacion
{
    partial class FrmStock
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
            lblFiltroProd = new Label();
            cboFiltroProducto = new ComboBox();
            lblFiltroUbi = new Label();
            cboFiltroUbicacion = new ComboBox();
            btnConsultar = new Button();
            dgvExistencias = new DataGridView();
            lblGruposTitulo = new Label();
            dgvGrupos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblTitulo.Location = new Point(25, 16);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(211, 37);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consultar stock";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblSubtitulo.ForeColor = Color.FromArgb(90, 105, 95);
            lblSubtitulo.Location = new Point(27, 55);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(106, 17);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Datos del registro";
            // 
            // lblFiltroProd
            // 
            lblFiltroProd.AutoSize = true;
            lblFiltroProd.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblFiltroProd.ForeColor = Color.FromArgb(90, 105, 95);
            lblFiltroProd.Location = new Point(25, 82);
            lblFiltroProd.Name = "lblFiltroProd";
            lblFiltroProd.Size = new Size(59, 17);
            lblFiltroProd.TabIndex = 2;
            lblFiltroProd.Text = "Producto";
            // 
            // cboFiltroProducto
            // 
            cboFiltroProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroProducto.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboFiltroProducto.FormattingEnabled = true;
            cboFiltroProducto.Location = new Point(25, 104);
            cboFiltroProducto.Name = "cboFiltroProducto";
            cboFiltroProducto.Size = new Size(340, 25);
            cboFiltroProducto.TabIndex = 3;
            // 
            // lblFiltroUbi
            // 
            lblFiltroUbi.AutoSize = true;
            lblFiltroUbi.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            lblFiltroUbi.ForeColor = Color.FromArgb(90, 105, 95);
            lblFiltroUbi.Location = new Point(385, 82);
            lblFiltroUbi.Name = "lblFiltroUbi";
            lblFiltroUbi.Size = new Size(63, 17);
            lblFiltroUbi.TabIndex = 4;
            lblFiltroUbi.Text = "Ubicación";
            // 
            // cboFiltroUbicacion
            // 
            cboFiltroUbicacion.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFiltroUbicacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            cboFiltroUbicacion.FormattingEnabled = true;
            cboFiltroUbicacion.Location = new Point(385, 104);
            cboFiltroUbicacion.Name = "cboFiltroUbicacion";
            cboFiltroUbicacion.Size = new Size(300, 25);
            cboFiltroUbicacion.TabIndex = 5;
            // 
            // btnConsultar
            // 
            btnConsultar.BackColor = Color.FromArgb(35, 107, 78);
            btnConsultar.Cursor = Cursors.Hand;
            btnConsultar.FlatAppearance.BorderSize = 0;
            btnConsultar.FlatStyle = FlatStyle.Flat;
            btnConsultar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConsultar.ForeColor = Color.White;
            btnConsultar.Location = new Point(705, 98);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(185, 34);
            btnConsultar.TabIndex = 6;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = false;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dgvExistencias
            // 
            dgvExistencias.AllowUserToAddRows = false;
            dgvExistencias.AllowUserToDeleteRows = false;
            dgvExistencias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvExistencias.BackgroundColor = Color.White;
            dgvExistencias.BorderStyle = BorderStyle.None;
            dgvExistencias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvExistencias.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvExistencias.Location = new Point(25, 145);
            dgvExistencias.MultiSelect = false;
            dgvExistencias.Name = "dgvExistencias";
            dgvExistencias.ReadOnly = true;
            dgvExistencias.RowHeadersVisible = false;
            dgvExistencias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExistencias.Size = new Size(865, 180);
            dgvExistencias.TabIndex = 7;
            dgvExistencias.SelectionChanged += dgvExistencias_SelectionChanged;
            // 
            // lblGruposTitulo
            // 
            lblGruposTitulo.AutoSize = true;
            lblGruposTitulo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblGruposTitulo.ForeColor = Color.FromArgb(30, 45, 38);
            lblGruposTitulo.Location = new Point(25, 340);
            lblGruposTitulo.Name = "lblGruposTitulo";
            lblGruposTitulo.Size = new Size(138, 25);
            lblGruposTitulo.TabIndex = 8;
            lblGruposTitulo.Text = "Grupos - unidad";
            // 
            // dgvGrupos
            // 
            dgvGrupos.AllowUserToAddRows = false;
            dgvGrupos.AllowUserToDeleteRows = false;
            dgvGrupos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGrupos.BackgroundColor = Color.White;
            dgvGrupos.BorderStyle = BorderStyle.None;
            dgvGrupos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGrupos.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            dgvGrupos.Location = new Point(25, 375);
            dgvGrupos.MultiSelect = false;
            dgvGrupos.Name = "dgvGrupos";
            dgvGrupos.ReadOnly = true;
            dgvGrupos.RowHeadersVisible = false;
            dgvGrupos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGrupos.Size = new Size(865, 185);
            dgvGrupos.TabIndex = 9;
            // 
            // FrmStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 243, 238);
            ClientSize = new Size(918, 590);
            Controls.Add(dgvGrupos);
            Controls.Add(lblGruposTitulo);
            Controls.Add(dgvExistencias);
            Controls.Add(btnConsultar);
            Controls.Add(cboFiltroUbicacion);
            Controls.Add(lblFiltroUbi);
            Controls.Add(cboFiltroProducto);
            Controls.Add(lblFiltroProd);
            Controls.Add(lblSubtitulo);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmStock";
            StartPosition = FormStartPosition.CenterParent;
            Text = "El Ahorrador - Gestión de inventarios y control de almacén";
            Load += FrmStock_Load;
            ((System.ComponentModel.ISupportInitialize)dgvExistencias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvGrupos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblFiltroProd;
        private ComboBox cboFiltroProducto;
        private Label lblFiltroUbi;
        private ComboBox cboFiltroUbicacion;
        private Button btnConsultar;
        private DataGridView dgvExistencias;
        private Label lblGruposTitulo;
        private DataGridView dgvGrupos;
    }
}

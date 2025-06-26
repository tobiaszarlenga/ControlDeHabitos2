namespace ControlDeHabitos2.Desktop
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            nudFrecuencia = new NumericUpDown();
            label4 = new Label();
            btnAgregar = new Button();
            process1 = new System.Diagnostics.Process();
            tabCargar = new TabPage();
            btnGuardarCambios = new Button();
            lblEditando = new Label();
            label5 = new Label();
            dtpFechaObjetivo = new DateTimePicker();
            lblUsuarioActivo = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label6 = new Label();
            btnEliminar = new Button();
            btnEditar = new Button();
            dataGridView1 = new DataGridView();
            btnCargar = new Button();
            menuStrip1 = new MenuStrip();
            cuentaToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)nudFrecuencia).BeginInit();
            tabCargar.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(541, 172);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(194, 31);
            txtNombre.TabIndex = 0;
            txtNombre.TextChanged += textBox1_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.AcceptsReturn = true;
            txtDescripcion.Location = new Point(541, 368);
            txtDescripcion.Margin = new Padding(4, 5, 4, 5);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(194, 39);
            txtDescripcion.TabIndex = 3;
            txtDescripcion.TextChanged += txtDescripcion_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(320, 177);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(166, 25);
            label1.TabIndex = 4;
            label1.Text = "Nombre del Habito";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(320, 368);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(187, 25);
            label2.TabIndex = 5;
            label2.Text = "Descripcion (opcional)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(320, 300);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(109, 25);
            label3.TabIndex = 6;
            label3.Text = "Fecha Limite";
            label3.Click += label3_Click;
            // 
            // nudFrecuencia
            // 
            nudFrecuencia.Location = new Point(541, 237);
            nudFrecuencia.Margin = new Padding(4, 5, 4, 5);
            nudFrecuencia.Name = "nudFrecuencia";
            nudFrecuencia.Size = new Size(51, 31);
            nudFrecuencia.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(320, 238);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(193, 25);
            label4.TabIndex = 8;
            label4.Text = "Frecuencia por semana";
            label4.Click += label4_Click;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(320, 450);
            btnAgregar.Margin = new Padding(4, 5, 4, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(107, 38);
            btnAgregar.TabIndex = 5;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // process1
            // 
            process1.StartInfo.Domain = "";
            process1.StartInfo.LoadUserProfile = false;
            process1.StartInfo.Password = null;
            process1.StartInfo.StandardErrorEncoding = null;
            process1.StartInfo.StandardInputEncoding = null;
            process1.StartInfo.StandardOutputEncoding = null;
            process1.StartInfo.UseCredentialsForNetworkingOnly = false;
            process1.StartInfo.UserName = "";
            process1.SynchronizingObject = this;
            // 
            // tabCargar
            // 
            tabCargar.Controls.Add(btnGuardarCambios);
            tabCargar.Controls.Add(lblEditando);
            tabCargar.Controls.Add(label5);
            tabCargar.Controls.Add(dtpFechaObjetivo);
            tabCargar.Controls.Add(btnAgregar);
            tabCargar.Controls.Add(label4);
            tabCargar.Controls.Add(nudFrecuencia);
            tabCargar.Controls.Add(txtNombre);
            tabCargar.Controls.Add(label3);
            tabCargar.Controls.Add(txtDescripcion);
            tabCargar.Controls.Add(label2);
            tabCargar.Controls.Add(label1);
            tabCargar.Location = new Point(4, 34);
            tabCargar.Margin = new Padding(4, 5, 4, 5);
            tabCargar.Name = "tabCargar";
            tabCargar.Padding = new Padding(4, 5, 4, 5);
            tabCargar.Size = new Size(1101, 602);
            tabCargar.TabIndex = 1;
            tabCargar.Text = "AGREGAR";
            tabCargar.UseVisualStyleBackColor = true;
            tabCargar.Click += tabPage2_Click;
            // 
            // btnGuardarCambios
            // 
            btnGuardarCambios.Location = new Point(320, 450);
            btnGuardarCambios.Margin = new Padding(4, 5, 4, 5);
            btnGuardarCambios.Name = "btnGuardarCambios";
            btnGuardarCambios.Size = new Size(203, 38);
            btnGuardarCambios.TabIndex = 4;
            btnGuardarCambios.Text = "Guardar Cambios";
            btnGuardarCambios.UseVisualStyleBackColor = true;
            btnGuardarCambios.Visible = false;
            btnGuardarCambios.Click += btnGuardarCambios_Click;
            // 
            // lblEditando
            // 
            lblEditando.AutoSize = true;
            lblEditando.Location = new Point(364, 122);
            lblEditando.Margin = new Padding(4, 0, 4, 0);
            lblEditando.Name = "lblEditando";
            lblEditando.Size = new Size(299, 25);
            lblEditando.TabIndex = 16;
            lblEditando.Text = "Estás editando el hábito: leer mucho";
            lblEditando.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(439, 55);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(205, 29);
            label5.TabIndex = 15;
            label5.Text = "NUEVO HABITO";
            label5.Click += label5_Click;
            // 
            // dtpFechaObjetivo
            // 
            dtpFechaObjetivo.Format = DateTimePickerFormat.Short;
            dtpFechaObjetivo.Location = new Point(541, 297);
            dtpFechaObjetivo.Margin = new Padding(4, 5, 4, 5);
            dtpFechaObjetivo.Name = "dtpFechaObjetivo";
            dtpFechaObjetivo.Size = new Size(134, 31);
            dtpFechaObjetivo.TabIndex = 2;
            dtpFechaObjetivo.ValueChanged += dtpFechaObjetivo_ValueChanged;
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Location = new Point(501, 15);
            lblUsuarioActivo.Margin = new Padding(4, 0, 4, 0);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(102, 25);
            lblUsuarioActivo.TabIndex = 13;
            lblUsuarioActivo.Text = "Usuario: ---";
            lblUsuarioActivo.TextAlign = ContentAlignment.MiddleRight;
            lblUsuarioActivo.Click += lblUsuarioActivo_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCargar);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(17, 45);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1109, 640);
            tabControl1.TabIndex = 14;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(btnEliminar);
            tabPage1.Controls.Add(btnEditar);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(btnCargar);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4, 5, 4, 5);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 5, 4, 5);
            tabPage1.Size = new Size(1101, 602);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "HABITOS";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(447, 57);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(184, 29);
            label6.TabIndex = 17;
            label6.Text = "TUS HABITOS";
            label6.Click += label6_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(170, 493);
            btnEliminar.Margin = new Padding(4, 5, 4, 5);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(206, 40);
            btnEliminar.TabIndex = 15;
            btnEliminar.Text = "Eliminar seleccionado";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(426, 493);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(111, 38);
            btnEditar.TabIndex = 16;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(170, 205);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(757, 250);
            dataGridView1.TabIndex = 13;
            dataGridView1.CellContentClick += dataGridView1_CellClick;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(170, 137);
            btnCargar.Margin = new Padding(4, 5, 4, 5);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(147, 38);
            btnCargar.TabIndex = 14;
            btnCargar.Text = "Cargar Habitos";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            menuStrip1.Dock = DockStyle.None;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cuentaToolStripMenuItem });
            menuStrip1.Location = new Point(856, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(274, 35);
            menuStrip1.TabIndex = 15;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // cuentaToolStripMenuItem
            // 
            cuentaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesionToolStripMenuItem });
            cuentaToolStripMenuItem.Name = "cuentaToolStripMenuItem";
            cuentaToolStripMenuItem.Size = new Size(83, 29);
            cuentaToolStripMenuItem.Text = "Cuenta";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(270, 34);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 748);
            Controls.Add(tabControl1);
            Controls.Add(lblUsuarioActivo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)nudFrecuencia).EndInit();
            tabCargar.ResumeLayout(false);
            tabCargar.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown nudFrecuencia;
        private Label label4;
        private Button btnAgregar;
        private System.Diagnostics.Process process1;
        private TabControl tabControl1;
        private TabPage tabCargar;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem cuentaToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private Label lblUsuarioActivo;
        private DateTimePicker dtpFechaObjetivo;
        private TabPage tabPage1;
        private Button btnEliminar;
        private Button btnEditar;
        private DataGridView dataGridView1;
        private Button btnCargar;
        private Label label5;
        private Label lblEditando;
        private Button btnGuardarCambios;
        private Label label6;
    }
}

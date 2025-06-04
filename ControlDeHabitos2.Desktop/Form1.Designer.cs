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
            dataGridView1 = new DataGridView();
            btnCargar = new Button();
            txtNombre = new TextBox();
            txtDescripcion = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            nudFrecuencia = new NumericUpDown();
            label4 = new Label();
            txtHoraObjetivo = new TextBox();
            btnAgregar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            process1 = new System.Diagnostics.Process();
            menuStrip1 = new MenuStrip();
            uSUARIOToolStripMenuItem = new ToolStripMenuItem();
            iniciarSesionToolStripMenuItem = new ToolStripMenuItem();
            registrorToolStripMenuItem = new ToolStripMenuItem();
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            tabPage2 = new TabPage();
            tabLogin = new TabPage();
            tabControl1 = new TabControl();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudFrecuencia).BeginInit();
            menuStrip1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabControl1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(345, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(337, 150);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // btnCargar
            // 
            btnCargar.Location = new Point(345, 29);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(103, 23);
            btnCargar.TabIndex = 1;
            btnCargar.Text = "Cargar Habitos";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(186, 70);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += textBox1_TextChanged;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(186, 110);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 74);
            label1.Name = "label1";
            label1.Size = new Size(109, 15);
            label1.TabIndex = 4;
            label1.Text = "Nombre del Habito";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 114);
            label2.Name = "label2";
            label2.Size = new Size(126, 15);
            label2.TabIndex = 5;
            label2.Text = "Descripcion (opcional)";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(31, 187);
            label3.Name = "label3";
            label3.Size = new Size(141, 15);
            label3.TabIndex = 6;
            label3.Text = "Hora Objetivo(hh:mm:ss)";
            label3.Click += label3_Click;
            // 
            // nudFrecuencia
            // 
            nudFrecuencia.Location = new Point(186, 149);
            nudFrecuencia.Name = "nudFrecuencia";
            nudFrecuencia.Size = new Size(100, 23);
            nudFrecuencia.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(31, 150);
            label4.Name = "label4";
            label4.Size = new Size(129, 15);
            label4.TabIndex = 8;
            label4.Text = "Frecuencia por semana";
            label4.Click += label4_Click;
            // 
            // txtHoraObjetivo
            // 
            txtHoraObjetivo.Location = new Point(186, 185);
            txtHoraObjetivo.Name = "txtHoraObjetivo";
            txtHoraObjetivo.Size = new Size(100, 23);
            txtHoraObjetivo.TabIndex = 9;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(131, 228);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(75, 23);
            btnAgregar.TabIndex = 10;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(345, 231);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(144, 24);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar seleccionado";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(604, 231);
            btnEditar.Margin = new Padding(2);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(78, 20);
            btnEditar.TabIndex = 12;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
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
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { uSUARIOToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 13;
            menuStrip1.Text = "menuStrip1";
            // 
            // uSUARIOToolStripMenuItem
            // 
            uSUARIOToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesionToolStripMenuItem, registrorToolStripMenuItem, cerrarSesionToolStripMenuItem });
            uSUARIOToolStripMenuItem.Name = "uSUARIOToolStripMenuItem";
            uSUARIOToolStripMenuItem.Size = new Size(68, 20);
            uSUARIOToolStripMenuItem.Text = "USUARIO";
            uSUARIOToolStripMenuItem.Click += uSUARIOToolStripMenuItem_Click;
            // 
            // iniciarSesionToolStripMenuItem
            // 
            iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            iniciarSesionToolStripMenuItem.Size = new Size(143, 22);
            iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            iniciarSesionToolStripMenuItem.Click += iniciarSesionToolStripMenuItem_Click;
            // 
            // registrorToolStripMenuItem
            // 
            registrorToolStripMenuItem.Name = "registrorToolStripMenuItem";
            registrorToolStripMenuItem.Size = new Size(143, 22);
            registrorToolStripMenuItem.Text = "Registrarse";
            registrorToolStripMenuItem.Click += registrarseToolStripMenuItem_Click;
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(143, 22);
            cerrarSesionToolStripMenuItem.Text = "Cerrar Sesion";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(btnEliminar);
            tabPage2.Controls.Add(btnAgregar);
            tabPage2.Controls.Add(btnEditar);
            tabPage2.Controls.Add(txtHoraObjetivo);
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(label4);
            tabPage2.Controls.Add(btnCargar);
            tabPage2.Controls.Add(nudFrecuencia);
            tabPage2.Controls.Add(txtNombre);
            tabPage2.Controls.Add(label3);
            tabPage2.Controls.Add(txtDescripcion);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 316);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "CARGAR";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // tabLogin
            // 
            tabLogin.Location = new Point(4, 24);
            tabLogin.Name = "tabLogin";
            tabLogin.Padding = new Padding(3);
            tabLogin.Size = new Size(768, 316);
            tabLogin.TabIndex = 0;
            tabLogin.Text = "USUARIO ";
            tabLogin.UseVisualStyleBackColor = true;
            tabLogin.Click += tabPage1_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabLogin);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 27);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 344);
            tabControl1.TabIndex = 14;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 449);
            Controls.Add(tabControl1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudFrecuencia).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnCargar;
        private TextBox txtNombre;
        private TextBox txtDescripcion;
        private Label label1;
        private Label label2;
        private Label label3;
        private NumericUpDown nudFrecuencia;
        private Label label4;
        private TextBox txtHoraObjetivo;
        private Button btnAgregar;
        private Button btnEliminar;
        private Button btnEditar;
        private System.Diagnostics.Process process1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem uSUARIOToolStripMenuItem;
        private ToolStripMenuItem iniciarSesionToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem registrorToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabLogin;
        private TabPage tabPage2;
    }
}

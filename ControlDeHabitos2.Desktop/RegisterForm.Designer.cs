namespace ControlDeHabitos2.Desktop
{
    partial class RegisterForm
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
            lblNombre = new Label();
            lblContraseña = new Label();
            txtNombre = new TextBox();
            txtContraseña = new TextBox();
            btnRegistar = new Button();
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(120, 97);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(110, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre de Usuario";
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Location = new Point(120, 142);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(67, 15);
            lblContraseña.TabIndex = 1;
            lblContraseña.Text = "Contraseña";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(245, 94);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(100, 23);
            txtNombre.TabIndex = 2;
            txtNombre.TextChanged += textBox1_TextChanged;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(245, 139);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(100, 23);
            txtContraseña.TabIndex = 3;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // btnRegistar
            // 
            btnRegistar.Location = new Point(194, 189);
            btnRegistar.Name = "btnRegistar";
            btnRegistar.Size = new Size(75, 23);
            btnRegistar.TabIndex = 4;
            btnRegistar.Text = "Registrar";
            btnRegistar.UseVisualStyleBackColor = true;
            btnRegistar.Click += btnRegistar_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 268);
            Controls.Add(btnRegistar);
            Controls.Add(txtContraseña);
            Controls.Add(txtNombre);
            Controls.Add(lblContraseña);
            Controls.Add(lblNombre);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private Label lblContraseña;
        private TextBox txtNombre;
        private TextBox txtContraseña;
        private Button btnRegistar;
    }
}
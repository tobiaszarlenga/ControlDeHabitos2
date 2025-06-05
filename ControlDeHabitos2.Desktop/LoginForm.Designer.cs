namespace ControlDeHabitos2.Desktop
{
    partial class LoginForm
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
            label1 = new Label();
            label2 = new Label();
            txtContraseña = new TextBox();
            txtUsuario = new TextBox();
            btnRegistrarse = new Button();
            btnLogin = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(100, 23);
            label1.TabIndex = 8;
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(100, 23);
            label2.TabIndex = 7;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(308, 190);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(133, 31);
            txtContraseña.TabIndex = 6;
            txtContraseña.UseSystemPasswordChar = true;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(308, 114);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(133, 31);
            txtUsuario.TabIndex = 3;
            // 
            // btnRegistrarse
            // 
            btnRegistrarse.Location = new Point(308, 263);
            btnRegistrarse.Name = "btnRegistrarse";
            btnRegistrarse.Size = new Size(133, 34);
            btnRegistrarse.TabIndex = 4;
            btnRegistrarse.Text = "Registrarse";
            btnRegistrarse.UseVisualStyleBackColor = true;
            btnRegistrarse.Click += btnRegistrarse_Click;
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(145, 263);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(134, 34);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Iniciar Sesion";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(145, 117);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 9;
            label3.Text = "Usuario";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(145, 193);
            label4.Name = "label4";
            label4.Size = new Size(101, 25);
            label4.TabIndex = 10;
            label4.Text = "Contraseña";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(617, 375);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(btnRegistrarse);
            Controls.Add(txtUsuario);
            Controls.Add(txtContraseña);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtContraseña;
        private TextBox txtUsuario;
        private Button btnRegistrarse;
        private Button btnLogin;
        private Label label3;
        private Label label4;
    }
}
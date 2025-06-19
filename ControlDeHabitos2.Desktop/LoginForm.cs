using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlDeHabitos2.API.Models;

namespace ControlDeHabitos2.Desktop
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.AcceptButton = btnLogin;

            txtContraseña.UseSystemPasswordChar = true;
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string nombre = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text;
           

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Nombre y contraseña son obligatorios.");
                return;
            }

            var usuario = new Usuario { Nombre = nombre, Contraseña = contraseña };

            try
            {
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7138/api/Usuarios/login", usuario);

                if (response.IsSuccessStatusCode)
                {
                    var usuarioLogueado = await response.Content.ReadFromJsonAsync<Usuario>();

                    if (usuarioLogueado == null)
                    {
                        MessageBox.Show("Error al procesar la respuesta del servidor.");
                        return;
                    }


                    Sesion.UsuarioId = usuarioLogueado.Id;
                    Sesion.NombreUsuario = usuarioLogueado.Nombre;
                    MessageBox.Show($"Sesión iniciada correctamente como: {usuarioLogueado.Nombre}");

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}");
            }
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            using (var form = new RegisterForm())
            {
                form.ShowDialog();
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus(); 
        }
    }
}

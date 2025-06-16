using ControlDeHabitos2.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlDeHabitos2.Desktop
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string contraseña = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Nombre y contraseña son obligatorios.");
                return;
            }

            var nuevoUsuario = new Usuario { Nombre = nombre, Contraseña = contraseña };

            try
            {
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7138/api/Usuarios", nuevoUsuario);

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al registrar usuario:\n{error}");
                    return;
                }

                var usuarioCreado = await response.Content.ReadFromJsonAsync<Usuario>();

                if (usuarioCreado == null)
                {
                    MessageBox.Show("Error: No se pudo leer el usuario desde la respuesta.");
                    return;
                }

                MessageBox.Show("Usuario registrado correctamente. Ahora podés iniciar sesión.");
                this.Close(); // Cierra el modal y vuelve al login
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        

        }
    }
}

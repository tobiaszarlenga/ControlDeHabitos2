using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ControlDeHabitos2.API.Models;


namespace ControlDeHabitos2.Desktop
{
    public partial class Form1 : Form
    {
        private Habito? habitoSeleccionado;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId != null)
            {
                lblUsuarioActivo.Text = $"Usuario: {Sesion.NombreUsuario}";
            }
            ActualizarUsuarioActual();
        }
        private async Task CargarHabitos()
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                return;
            }

            try
            {
                var client = new HttpClient();
                var habitos = await client.GetFromJsonAsync<List<Habito>>(
                    $"https://localhost:7138/api/Habitos/usuario/{Sesion.UsuarioId}"
                );
                dataGridView1.DataSource = habitos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener hábitos: {ex.Message}");
            }
        }


        private async void btnCargar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                return;
            }

            try
            {
                var client = new HttpClient();
                var habitos = await client.GetFromJsonAsync<List<Habito>>(
                    $"https://localhost:7138/api/Habitos/usuario/{Sesion.UsuarioId}"
                );
                dataGridView1.DataSource = habitos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener hábitos: {ex.Message}");
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                return;
            }

            try
            {
                var nuevoHabito = new Habito


                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    FrecuenciaPorSemana = (int)nudFrecuencia.Value,
                    FechaObjetivo = dtpFechaObjetivo.Value,
                    FechaInicio = DateTime.Now,
                    EstaActivo = true,
                    EstaCompletoHoy = false,
                    DiasCompletados = 0,
                    FechaCreacion = DateTime.Now,
                    FechaUltimaCompletacion = null,
                    UsuarioId = Sesion.UsuarioId.Value // ¡IMPORTANTE!
                };

                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7138/api/Habitos", nuevoHabito);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Hábito agregado correctamente.");
                    btnCargar.PerformClick();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al agregar hábito:\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}");
            }
        }


        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un hábito para eliminar.");
                return;
            }

            var habitoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Habito;
            if (habitoSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el hábito.");
                return;
            }

            var resultado = MessageBox.Show(
                $"¿Estás seguro de que quieres eliminar '{habitoSeleccionado.Nombre}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var client = new HttpClient();
                    var response = await client.DeleteAsync($"https://localhost:7138/api/Habitos/{habitoSeleccionado.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Hábito eliminado correctamente.");
                        btnCargar.PerformClick();
                    }
                    else
                    {
                        var error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al eliminar: {error}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }


        private async void btnEditar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un hábito para editar.");
                return;
            }

            var habitoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Habito;

            if (habitoSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el hábito.");
                return;
            }

            // Actualizamos datos del formulario
            habitoSeleccionado.Nombre = txtNombre.Text;
            habitoSeleccionado.Descripcion = txtDescripcion.Text;
            habitoSeleccionado.FrecuenciaPorSemana = (int)nudFrecuencia.Value;
            habitoSeleccionado.UsuarioId = Sesion.UsuarioId.Value; // ¡Aseguramos que tenga el usuario correcto!
            habitoSeleccionado.FechaObjetivo = dtpFechaObjetivo.Value;


            try
            {
                var client = new HttpClient();
                var response = await client.PutAsJsonAsync(
                    $"https://localhost:7138/api/Habitos/{habitoSeleccionado.Id}",
                    habitoSeleccionado
                );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Hábito actualizado correctamente.");
                    await CargarHabitos();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar el hábito:\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                var habitoSeleccionado = dataGridView1.Rows[e.RowIndex].DataBoundItem as Habito;
                if (habitoSeleccionado == null) return;


                txtNombre.Text = habitoSeleccionado.Nombre;
                txtDescripcion.Text = habitoSeleccionado.Descripcion;
                nudFrecuencia.Value = habitoSeleccionado.FrecuenciaPorSemana;
                if (habitoSeleccionado.FechaObjetivo != null)
                {
                    dtpFechaObjetivo.Value = habitoSeleccionado.FechaObjetivo.Value;
                }




                this.habitoSeleccionado = habitoSeleccionado;
            }
        }






        private void uSUARIOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {



            string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre de usuario:");
            string contraseña = Microsoft.VisualBasic.Interaction.InputBox("Contraseña:");

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
                    MessageBox.Show($"Sesión iniciada correctamente como: {usuarioLogueado.Nombre}");

                    await CargarHabitos();
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

        private async void btnRegistrarse_Click(object sender, EventArgs e)
        {
            string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre de usuario:");
            string contraseña = Microsoft.VisualBasic.Interaction.InputBox("Contraseña:");

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

                Sesion.UsuarioId = usuarioCreado.Id;
                MessageBox.Show($"Usuario registrado correctamente como: {usuarioCreado.Nombre}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("No hay sesión activa.");
                return;
            }

            var confirm = MessageBox.Show("¿Estás seguro de cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Sesion.UsuarioId = null;
                MessageBox.Show("Sesión cerrada correctamente.");
                dataGridView1.DataSource = null;

                // Limpiar campos del formulario si querés
                txtNombre.Clear();
                txtDescripcion.Clear();
                dtpFechaObjetivo.Value = DateTime.Today;

                nudFrecuencia.Value = 0;
                this.Close();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private async void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("¿Estás seguro de cerrar sesión?", "Confirmar", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Sesion.UsuarioId = null;
                Sesion.NombreUsuario = null;
                MessageBox.Show("Sesión cerrada correctamente.");

                this.Hide();

                var login = new LoginForm();
                var resultado = login.ShowDialog();

                if (resultado == DialogResult.OK && Sesion.UsuarioId != null)
                {
                    ActualizarUsuarioActual();
                    await CargarHabitos();
                    this.Show();
                }
                else
                {
                    this.Close();


                }
            }
        }

        private void ActualizarUsuarioActual()
        {
            lblUsuarioActivo.Text = $"Usuario: {Sesion.NombreUsuario}";
        }

        private void lblUsuarioActivo_Click(object sender, EventArgs e)
        {

            MessageBox.Show($"Estás logueado como: {Sesion.NombreUsuario}");
        }

        private void dtpFechaObjetivo_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}










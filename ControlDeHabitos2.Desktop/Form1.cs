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

        }
        private async Task CargarHabitos()
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesi�n.");
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
                MessageBox.Show($"Error al obtener h�bitos: {ex.Message}");
            }
        }


        private async void btnCargar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesi�n.");
                return;
            }

            try
            {
                var client = new HttpClient();
                var url = $"https://localhost:7138/api/Habitos/usuario/{Sesion.UsuarioId}";
                var habitos = await client.GetFromJsonAsync<List<Habito>>(url);
                dataGridView1.DataSource = habitos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener h�bitos: {ex.Message}");
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
                MessageBox.Show("Debes iniciar sesi�n.");
                return;
            }

            try
            {
                var nuevoHabito = new Habito
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    FrecuenciaPorSemana = (int)nudFrecuencia.Value,
                    HoraObjetivo = TimeSpan.TryParse(txtHoraObjetivo.Text, out var hora) ? hora : null,
                    FechaInicio = DateTime.Now,
                    EstaActivo = true,
                    EstaCompletoHoy = false,
                    DiasCompletados = 0,
                    FechaCreacion = DateTime.Now,
                    FechaUltimaCompletacion = null,
                    UsuarioId = Sesion.UsuarioId.Value // �IMPORTANTE!
                };

                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7138/api/Habitos", nuevoHabito);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("H�bito agregado correctamente.");
                    btnCargar.PerformClick();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al agregar h�bito:\n{error}");
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
                MessageBox.Show("Debes iniciar sesi�n.");
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un h�bito para eliminar.");
                return;
            }

            var habitoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Habito;
            if (habitoSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el h�bito.");
                return;
            }

            var resultado = MessageBox.Show(
                $"�Est�s seguro de que quieres eliminar '{habitoSeleccionado.Nombre}'?",
                "Confirmar eliminaci�n", MessageBoxButtons.YesNo);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var client = new HttpClient();
                    var response = await client.DeleteAsync($"https://localhost:7138/api/Habitos/{habitoSeleccionado.Id}");

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("H�bito eliminado correctamente.");
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
                MessageBox.Show("Debes iniciar sesi�n.");
                return;
            }

            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Seleccion� un h�bito para editar.");
                return;
            }

            var habitoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Habito;

            if (habitoSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el h�bito.");
                return;
            }

            // Actualizamos datos del formulario
            habitoSeleccionado.Nombre = txtNombre.Text;
            habitoSeleccionado.Descripcion = txtDescripcion.Text;
            habitoSeleccionado.FrecuenciaPorSemana = (int)nudFrecuencia.Value;
            habitoSeleccionado.UsuarioId = Sesion.UsuarioId.Value; // �Aseguramos que tenga el usuario correcto!

            if (TimeSpan.TryParse(txtHoraObjetivo.Text, out TimeSpan hora))
            {
                habitoSeleccionado.HoraObjetivo = hora;
            }
            else
            {
                habitoSeleccionado.HoraObjetivo = null;
            }

            try
            {
                var client = new HttpClient();
                var response = await client.PutAsJsonAsync(
                    $"https://localhost:7138/api/Habitos/{habitoSeleccionado.Id}",
                    habitoSeleccionado
                );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("H�bito actualizado correctamente.");
                    await CargarHabitos();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al actualizar el h�bito:\n{error}");
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
                txtHoraObjetivo.Text = habitoSeleccionado.HoraObjetivo?.ToString() ?? "";


                this.habitoSeleccionado = habitoSeleccionado;
            }
        }

        private async void iniciarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {


            
            string nombre = Microsoft.VisualBasic.Interaction.InputBox("Nombre de usuario:");
            string contrase�a = Microsoft.VisualBasic.Interaction.InputBox("Contrase�a:");

            var usuario = new Usuario { Nombre = nombre, Contrase�a = contrase�a };
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
                    MessageBox.Show($"Sesi�n iniciada correctamente como: {usuarioLogueado.Nombre}");

                    await CargarHabitos();
                }

                else
                {
                    MessageBox.Show("Usuario o contrase�a incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesi�n: {ex.Message}");
            }


        }
    }
    
}









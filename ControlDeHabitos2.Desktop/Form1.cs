using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ControlDeHabitos2.Desktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private async Task CargarHabitos()
        {
            try
            {
                var client = new HttpClient();
                var habitos = await client.GetFromJsonAsync<List<Habito>>("https://localhost:7138/api/Habitos");
                dataGridView1.DataSource = habitos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener hábitos: {ex.Message}");
            }
        }


        private async void btnCargar_Click(object sender, EventArgs e)

        {
            try
            {
                var client = new HttpClient();
                var habitos = await client.GetFromJsonAsync<List<Habito>>("https://localhost:7138/api/Habitos");
                dataGridView1.DataSource = habitos;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener habitos: {ex.Message}");
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
                    FechaUltimaCompletacion = null


                };
                var client = new HttpClient();
                var response = await client.PostAsJsonAsync("https://localhost:7138/api/Habitos", nuevoHabito);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Habito agregado correctamente. ");
                    btnCargar.PerformClick();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Error al agregar Habito:\n{error}");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error:\n{ex.Message}");
            }


        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un habito para eliminar");
                return;

            }
            var habitoSeleccionado = dataGridView1.CurrentRow.DataBoundItem as Habito;

            if (habitoSeleccionado == null)
            {
                MessageBox.Show("No se pudo obtener el habito. ");
                return;
            }
            var resultado = MessageBox.Show($"Estas seguro que queres eliminar '{habitoSeleccionado.Nombre}'?",
                "confirmar eliminacion", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    var client = new HttpClient();
                    var response = await client.DeleteAsync($"https://localhost:7138/api/Habitos/{habitoSeleccionado.Id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("habito eliminado correctamente. ");
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
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
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

            // Actualizamos los datos del hábito con lo que el usuario escribió en los inputs
            habitoSeleccionado.Nombre = txtNombre.Text;
            habitoSeleccionado.Descripcion = txtDescripcion.Text;
            habitoSeleccionado.FrecuenciaPorSemana = (int)nudFrecuencia.Value;

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
                    MessageBox.Show("Hábito actualizado correctamente.");
                    await CargarHabitos(); // Método que refresca el DataGridView
                }
                else
                {
                    MessageBox.Show("Error al actualizar el hábito.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

    }
}


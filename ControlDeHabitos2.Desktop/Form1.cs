using ControlDeHabitos2.API.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ControlDeHabitos2.Desktop
{
    public partial class Form1 : Form
    {
        private Habito? habitoSeleccionado;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.DataBindingComplete += dataGridView1_DataBindingComplete;
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


        private readonly HttpClient _httpClient = new();

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Debes iniciar sesión.");
                return;
            }

            try
            {
                var habitos = await _httpClient.GetFromJsonAsync<List<Habito>>(
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
                    LimpiarFormularioHabito();
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


        private void btnEditar_Click(object sender, EventArgs e)
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

            // Cargamos los datos en los campos
            txtNombre.Text = habitoSeleccionado.Nombre;
            txtDescripcion.Text = habitoSeleccionado.Descripcion;
            nudFrecuencia.Value = habitoSeleccionado.FrecuenciaPorSemana;

            // Aseguramos que la fecha no sea null
            dtpFechaObjetivo.Value = habitoSeleccionado.FechaObjetivo ?? DateTime.Today;

            // Guardamos el ID para usar después al guardar cambios
            btnGuardarCambios.Tag = habitoSeleccionado.Id;

            // Mostramos mensaje de edición
            lblEditando.Text = $"🔧 Estás editando el hábito: {habitoSeleccionado.Nombre}";
            lblEditando.Visible = true;

            // Alternamos los botones
            btnGuardarCambios.Visible = true;
            btnAgregar.Visible = false;

            // Cambiamos de pestaña al tab "CARGAR"
            tabControl1.SelectedTab = tabCargar;

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
                LimpiarFormularioHabito();
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

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarFormulario()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            nudFrecuencia.Value = 0;
            dtpFechaObjetivo.Value = DateTime.Today;
        }


        private async void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            if (btnGuardarCambios.Tag == null)
            {
                MessageBox.Show("No hay hábito seleccionado para editar.");
                return;
            }

            int idHabito = (int)btnGuardarCambios.Tag;
            if (Sesion.UsuarioId == null)
            {
                MessageBox.Show("Sesión expirada. Debes iniciar sesión nuevamente.");
                return;
            }

            var habitoEditado = new Habito
            {
                Id = idHabito,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                FrecuenciaPorSemana = (int)nudFrecuencia.Value,
                FechaObjetivo = dtpFechaObjetivo.Value,

                UsuarioId = Sesion.UsuarioId.Value
            };

            try
            {
                var client = new HttpClient();
                var response = await client.PutAsJsonAsync(
                    $"https://localhost:7138/api/Habitos/{idHabito}",
                    habitoEditado
                );

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Hábito editado correctamente.");

                    // Actualiza la grilla
                    await CargarHabitos();

                    // Reset visual
                    btnGuardarCambios.Visible = false;
                    btnAgregar.Visible = true;
                    lblEditando.Visible = false;
                    btnGuardarCambios.Tag = null;
                    LimpiarFormulario();

                    // Cambiamos a la pestaña de hábitos si querés
                    tabControl1.SelectedTab = tabPage1; // o como se llame el tab de visualización
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

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {
            var txt = sender as TextBox;
            if (txt == null) return;

            // Solo actualiza el alto si el texto excede la altura actual
            Size size = TextRenderer.MeasureText(txt.Text, txt.Font, new Size(txt.Width, int.MaxValue), TextFormatFlags.WordBreak);
            int nuevaAltura = size.Height + 10;
            if (nuevaAltura > txt.MinimumSize.Height)
                txt.Height = nuevaAltura;
        }
        private void dataGridView1_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            OcultarColumnaSiExiste("Id");
            OcultarColumnaSiExiste("UsuarioId");
            OcultarColumnaSiExiste("FechaUltimaCompletacion");
        }

        private void OcultarColumnaSiExiste(string nombre)
        {
            if (dataGridView1.Columns.Contains(nombre))
            {
                var columna = dataGridView1.Columns[nombre];
                if (columna != null)
                    columna.Visible = false;
            }
        }

        private void LimpiarFormularioHabito()
        {
            txtNombre.Text = "";
            nudFrecuencia.Value = 0;
            dtpFechaObjetivo.Value = DateTime.Now;
            txtDescripcion.Text = "";
            habitoSeleccionado = null;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}










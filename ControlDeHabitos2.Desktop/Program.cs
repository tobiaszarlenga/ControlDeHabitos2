using ControlDeHabitos2.Desktop;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize(); // o EnableVisualStyles si es .NET Framework

        var loginForm = new LoginForm();
        // Si el usuario inicia sesión correctamente
        if (loginForm.ShowDialog() == DialogResult.OK)
        {
            Application.Run(new Form1());
        }
        // Si no inicia sesión, la app termina acá (¡esto está bien!)
    }
}

namespace ControlDeHabitos2.API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Contraseña { get; set; } = string.Empty;
    }
}

namespace ControlDeHabitos2.API.Models
{
    public class Habito
    {
       
            public int Id { get; set; }                            
            public string Nombre { get; set; } = string.Empty;     
            public string? Descripcion { get; set; }              
            public DateTime FechaInicio { get; set; }              
            public int FrecuenciaPorSemana { get; set; }
        public DateTime? FechaObjetivo { get; set; }

        public bool EstaActivo { get; set; }                   
            public bool EstaCompletoHoy { get; set; }              
            public int DiasCompletados { get; set; }               
            public DateTime FechaCreacion { get; set; }            
            public DateTime? FechaUltimaCompletacion { get; set; }
            public int UsuarioId { get; set; }

        

}
}

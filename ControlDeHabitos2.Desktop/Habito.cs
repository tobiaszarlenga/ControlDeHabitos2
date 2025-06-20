using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlDeHabitos2.Desktop
{
    internal class Habito
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
        public int UsuarioId { get; internal set; }
    }
}

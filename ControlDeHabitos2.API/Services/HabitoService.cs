using ControlDeHabitos2.API.Interfaces;
using ControlDeHabitos2.API.Models;


namespace ControlDeHabitos2.API.Services
{
    public class HabitoService : IHabitoService
    {
        private readonly List<Habito> _habitos = new();
        private int _siguienteId = 1;
        public List<Habito> ObtenerTodos()
        {
            return _habitos;
        }
        public Habito? ObtenerPorId(int id)
        {
            return _habitos.FirstOrDefault(h => h.Id == id);
        }

        public void Crear(Habito nuevoHabito)
        {
            nuevoHabito.Id = _siguienteId++;
            nuevoHabito.FechaCreacion = DateTime.Now;
            _habitos.Add(nuevoHabito);
        }
        public void Actualizar(Habito habitoActualizado)
        {
            var existente = ObtenerPorId(habitoActualizado.Id);
            if (existente is null) return;
            existente.Nombre = habitoActualizado.Nombre;
            existente.Descripcion = habitoActualizado.Descripcion;
            existente.FechaInicio = habitoActualizado.FechaInicio;
            existente.FrecuenciaPorSemana = habitoActualizado.FrecuenciaPorSemana;
            existente.HoraObjetivo = habitoActualizado.HoraObjetivo;
            existente.EstaActivo = habitoActualizado.EstaActivo;
            existente.EstaCompletoHoy = habitoActualizado.EstaCompletoHoy;
            existente.DiasCompletados = habitoActualizado.DiasCompletados;
            existente.FechaUltimaCompletacion = habitoActualizado.FechaUltimaCompletacion;

        }
        public void Eliminar(int id)
        { 
            var habito = ObtenerPorId(id);
            if (habito is not null)
                _habitos.Remove(habito);
         
                }

       
    }
}

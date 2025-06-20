using ControlDeHabitos2.API.Models;
using ControlDeHabitos2.API.Interfaces;

namespace ControlDeHabitos2.API.Repositories
{
    public class HabitoRepository : IHabitoRepository
    {
        private readonly List<Habito> _habitos = new();
        private int _siguienteId = 1;

        public List<Habito> ObtenerPorUsuarioId(int usuarioId)
        {
            return _habitos.Where(h => h.UsuarioId == usuarioId).ToList();
        }

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
            existente.FechaObjetivo = habitoActualizado.FechaObjetivo;
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

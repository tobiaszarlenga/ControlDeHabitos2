using ControlDeHabitos2.API.Models;
using ControlDeHabitos2.API.Interfaces;
using ControlDeHabitos2.API.Data;
using Microsoft.EntityFrameworkCore;

namespace ControlDeHabitos2.API.Repositories
{
    public class HabitoRepository : IHabitoRepository
    {
        private readonly AppDbContext _context;

        public HabitoRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Habito> ObtenerPorUsuarioId(int usuarioId)
        {
            return _context.Habitos
                .Where(h => h.UsuarioId == usuarioId)
                .ToList();
        }

        public List<Habito> ObtenerTodos()
        {
            return _context.Habitos.ToList();
        }

        public Habito? ObtenerPorId(int id)
        {
            return _context.Habitos.FirstOrDefault(h => h.Id == id);
        }

        public void Crear(Habito nuevoHabito)
        {
            nuevoHabito.FechaCreacion = DateTime.Now;
            _context.Habitos.Add(nuevoHabito);
            _context.SaveChanges();
        }

        public void Actualizar(Habito habitoActualizado)
        {
            var existente = _context.Habitos.FirstOrDefault(h => h.Id == habitoActualizado.Id);
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

            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var habito = _context.Habitos.FirstOrDefault(h => h.Id == id);
            if (habito is not null)
            {
                _context.Habitos.Remove(habito);
                _context.SaveChanges();
            }
        }
    }
}

using ControlDeHabitos2.API.Interfaces;
using ControlDeHabitos2.API.Models;

namespace ControlDeHabitos2.API.Services
{
    public class HabitoService : IHabitoService
    {
        private readonly IHabitoRepository _repo;

        public HabitoService(IHabitoRepository repo)
        {
            _repo = repo;
        }

        public List<Habito> ObtenerPorUsuarioId(int usuarioId) => _repo.ObtenerPorUsuarioId(usuarioId);

        public List<Habito> ObtenerTodos() => _repo.ObtenerTodos();

        public Habito? ObtenerPorId(int id) => _repo.ObtenerPorId(id);

        public void Crear(Habito nuevoHabito) => _repo.Crear(nuevoHabito);

        public void Actualizar(Habito habitoActualizado) => _repo.Actualizar(habitoActualizado);

        public void Eliminar(int id) => _repo.Eliminar(id);
    }
}

using ControlDeHabitos2.API.Models;
using ControlDeHabitos2.API.Interfaces;

namespace ControlDeHabitos2.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repositorio;

        public UsuarioService(IUsuarioRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public void Crear(Usuario usuario)
        {
            // Validación básica
            if (string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Contraseña))
                throw new Exception("Nombre y contraseña son obligatorios.");

            _repositorio.Agregar(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _repositorio.ObtenerTodos();
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _repositorio.ObtenerPorId(id);
        }
        public void Actualizar(Usuario usuario)
        {
            var existente = _repositorio.ObtenerPorId(usuario.Id);
            if (existente == null)
                throw new Exception("Usuario no encontrado.");

            existente.Nombre = usuario.Nombre;
            existente.Contraseña = usuario.Contraseña;
        }

        public void Eliminar(int id)
        {
            _repositorio.Eliminar(id);
        }
        public Usuario? Validar(string nombre, string contraseña)
        {
            return _repositorio.ObtenerTodos()
                .FirstOrDefault(u => u.Nombre == nombre && u.Contraseña == contraseña);
        }


    }
}

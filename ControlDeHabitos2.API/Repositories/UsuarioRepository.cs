using ControlDeHabitos2.API.Interfaces;
using ControlDeHabitos2.API.Models;

namespace ControlDeHabitos2.API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly List<Usuario> _usuarios = new();
        private int _siguienteId = 1;

        public void Agregar(Usuario usuario)
        {
            usuario.Id = _siguienteId++;
            _usuarios.Add(usuario);
        }

        public List<Usuario> ObtenerTodos()
        {
            return _usuarios;
        }

        public Usuario? ObtenerPorId(int id)
        {
            return _usuarios.FirstOrDefault(u => u.Id == id);
        }
        public void Eliminar(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _usuarios.Remove(usuario);
            }
        }

        public Usuario? ValidarLogin(string nombre, string contraseña)
        {
            return _usuarios.FirstOrDefault(u =>
                u.Nombre == nombre && u.Contraseña == contraseña);
        }

    }
}

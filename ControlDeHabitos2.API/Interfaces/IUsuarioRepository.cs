using ControlDeHabitos2.API.Models;

namespace ControlDeHabitos2.API.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> ObtenerTodos();
        Usuario? ObtenerPorId(int id);
        void Agregar(Usuario usuario);
        void Eliminar(int id);
        bool ExistePorNombre(string nombre);

        Usuario? ObtenerPorCredenciales(string nombre, string contraseña);
      

    }
}

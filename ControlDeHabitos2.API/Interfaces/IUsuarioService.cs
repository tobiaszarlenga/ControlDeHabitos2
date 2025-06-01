using ControlDeHabitos2.API.Models;

namespace ControlDeHabitos2.API.Interfaces
{
    public interface IUsuarioService
    {
        List<Usuario> ObtenerTodos();
        Usuario? ObtenerPorId(int id);
        void Crear(Usuario nuevoUsuario);
        void Actualizar(Usuario usuarioActualizado);
        void Eliminar(int id);
    }
}

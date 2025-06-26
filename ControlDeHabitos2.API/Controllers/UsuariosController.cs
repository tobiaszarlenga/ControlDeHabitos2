using Microsoft.AspNetCore.Mvc;
using ControlDeHabitos2.API.Models;
using ControlDeHabitos2.API.Interfaces;

namespace ControlDeHabitos2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public IActionResult Crear([FromBody] Usuario usuario)
        {
            try
            {
                _usuarioService.Crear(usuario);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = usuario.Id }, usuario);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Nombre) || string.IsNullOrWhiteSpace(usuario.Contraseña))
                return BadRequest("Nombre y contraseña son requeridos.");

            var usuarioExistente = _usuarioService.Validar(usuario.Nombre, usuario.Contraseña);
            if (usuarioExistente == null)
                return Unauthorized("Usuario o contraseña incorrectos");

            return Ok(usuarioExistente);
        }


        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            var usuario = _usuarioService.ObtenerPorId(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var usuarios = _usuarioService.ObtenerTodos();
            return Ok(usuarios);
        }

        [HttpPut("{id}")]
        public IActionResult Actualizar(int id, [FromBody] Usuario usuarioActualizado)
        {
            try
            {
                usuarioActualizado.Id = id;
                _usuarioService.Actualizar(usuarioActualizado);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            _usuarioService.Eliminar(id);
            return NoContent();
        }
    }
}

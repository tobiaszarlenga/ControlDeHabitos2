using Microsoft.AspNetCore.Mvc;
using ControlDeHabitos2.API.Models;
using ControlDeHabitos2.API.Interfaces;

namespace ControlDeHabitos2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HabitosController : ControllerBase
    {
        private readonly IHabitoService _habitoService;

        public HabitosController(IHabitoService habitoService)
        {
            _habitoService = habitoService;
        }

        [HttpGet]
        public ActionResult<List<Habito>> Get()
        {
            return Ok(_habitoService.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public ActionResult<Habito> GetById(int id)
        {
            var habito = _habitoService.ObtenerPorId(id);
            if (habito == null) return NotFound();
            return Ok(habito);

        }
       
        [HttpGet("usuario/{usuarioId}")]
        public IActionResult ObtenerPorUsuario(int usuarioId)
        {
            var habitos = _habitoService.ObtenerPorUsuarioId(usuarioId);
            return Ok(habitos);
        }



        [HttpPost]
        public IActionResult Post([FromBody] Habito nuevoHabito)
        {
            nuevoHabito.Usuario = default!;

            _habitoService.Crear(nuevoHabito);
            return CreatedAtAction(nameof(GetById), new { id = nuevoHabito.Id }, nuevoHabito);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Habito habitoActualizado)
        {
            if (id != habitoActualizado.Id) return BadRequest();
            _habitoService.Actualizar(habitoActualizado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _habitoService.Eliminar(id);
            return NoContent();
        }
    }
}

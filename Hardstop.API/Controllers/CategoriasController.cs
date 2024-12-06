using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hardstop.API.Controllers
{
    [Route("api/categoria")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly HardstopDbContext _context;
        public CategoriasController(HardstopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Categorias.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var usuario = _context.Categorias.SingleOrDefault(d => d.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(CategoriaDTO dto)
        {
            // Converte o DTO para a entidade
            var categoria = new Categoria(
                Guid.NewGuid(),
                dto.Nome
            );

            _context.Categorias.Add(categoria);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, Categoria dto)
        {
            var categoria = _context.Categorias.SingleOrDefault(d => d.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Update(dto.Nome);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _context.Categorias.SingleOrDefault(d => d.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            return NoContent();
        }
    }
}

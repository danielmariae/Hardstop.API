using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hardstop.API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly HardstopDbContext _context;
        public UsuariosController(HardstopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _context.Usuarios.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(d => d.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(UsuarioDTO dto)
        {
            // Converte o DTO para a entidade
            var usuario = new Usuario(
                Guid.NewGuid(),
                dto.Nome,
                dto.Email,
                dto.Senha
            );

            _context.Usuarios.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UsuarioDTO input)
        {
            var usuario = _context.Usuarios.SingleOrDefault(d => d.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Update(input.Nome, input.Email, input.Senha);
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


        [HttpPost("{id}/favoritos")]
        public IActionResult PostFavorito(Guid id, Produto produto)
        {
            var user = _context.Usuarios.SingleOrDefault(d => d.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Favoritos.Produtos.Add(produto);
            return NoContent();
        }

        [HttpDelete("{id}/favoritos")]
        public IActionResult RemoveFavorito(Guid id, Produto produto)
        {
            var user = _context.Usuarios.SingleOrDefault(d => d.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Favoritos.Produtos.Remove(produto);
            return NoContent();
        }
    } 
}

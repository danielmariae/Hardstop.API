using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hardstop.API.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar as categorias.
    /// </summary>
    [Route("api/categoria")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly HardstopDbContext _context;

        /// <summary>
        /// Inicializa o controller com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public CategoriasController(HardstopDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as categorias cadastradas.
        /// </summary>
        /// <remarks>
        /// Exemplo de resposta:
        /// 
        ///     GET
        ///     [
        ///         {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "nome": "Categoria Exemplo"
        ///         }
        ///     ]
        ///     
        /// </remarks>
        /// <response code="200">Retorna a lista de categorias.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var categorias = _context.Categorias.ToList();
            return Ok(categorias);
        }

        /// <summary>
        /// Retorna os dados de uma categoria específica pelo ID.
        /// </summary>
        /// <param name="id">ID da categoria.</param>
        /// <remarks>
        /// Exemplo de resposta:
        /// 
        ///     GET
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "nome": "Categoria Exemplo"
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Retorna a categoria correspondente ao ID.</response>
        /// <response code="404">Categoria não encontrada.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var categoria = _context.Categorias.SingleOrDefault(d => d.Id == id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

        /// <summary>
        /// Cria uma nova categoria.
        /// </summary>
        /// <param name="dto">Dados da categoria a ser criada.</param>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     POST
        ///     {
        ///         "nome": "Nova Categoria"
        ///     }
        /// 
        /// Exemplo de resposta:
        /// 
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "nome": "Nova Categoria"
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Categoria criada com sucesso.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(CategoriaDTO dto)
        {
            var categoria = new Categoria(
                Guid.NewGuid(),
                dto.Nome
            );

            _context.Categorias.Add(categoria);
            return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
        }

        /// <summary>
        /// Atualiza os dados de uma categoria existente.
        /// </summary>
        /// <param name="id">ID da categoria a ser atualizada.</param>
        /// <param name="dto">Novos dados da categoria.</param>
        /// <remarks>
        /// Exemplo de request:
        /// 
        ///     PUT
        ///     {
        ///         "nome": "Categoria Atualizada"
        ///     }
        ///     
        /// </remarks>
        /// <response code="204">Categoria atualizada com sucesso.</response>
        /// <response code="404">Categoria não encontrada.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Exclui uma categoria existente.
        /// </summary>
        /// <param name="id">ID da categoria a ser excluída.</param>
        /// <response code="204">Categoria excluída com sucesso.</response>
        /// <response code="404">Categoria não encontrada.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

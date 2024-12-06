using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Mvc;


namespace Hardstop.API.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly HardstopDbContext _context;

        public ProdutosController(HardstopDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Post(ProdutoDTO dto)
        {
            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Estoque = dto.Estoque,
                Categoria = null // Ajuste conforme a lógica de sua aplicação para associar uma categoria.
            };

            _context.Produtos.Add(produto);

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ProdutoDTO input)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            produto.Update(input.Nome, input.Descricao, input.Preco, input.Estoque);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);

            return NoContent();
        }
    }
}

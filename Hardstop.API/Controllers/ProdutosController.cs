using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Hardstop.API.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar produtos.
    /// </summary>
    [Route("api/produto")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly HardstopDbContext _context;

        /// <summary>
        /// Inicializa o controller com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public ProdutosController(HardstopDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna a lista de todos os produtos cadastrados.
        /// </summary>
        /// <remarks>
        /// Retorno:
        /// 
        ///     GET /api/produto
        ///     [
        ///         {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "nome": "Produto Exemplo",
        ///             "descricao": "Descrição do produto",
        ///             "preco": 99.99,
        ///             "estoque": 10,
        ///             "categoria": {
        ///                 "id": "2a8e22d5-dff9-4a3b-bc42-d02a6bfc2e63",
        ///                 "nome": "Eletrônicos"
        ///             }
        ///         }
        ///     ]
        ///     
        /// </remarks>
        /// <response code="200">Retorna a lista de produtos com suas respectivas categorias.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var produtos = _context.Produtos
                .Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Descricao,
                    p.Preco,
                    p.Estoque,
                    Categoria = new { p.Categoria.Id, p.Categoria.Nome }
                })
                .ToList();
            return Ok(produtos);
        }

        /// <summary>
        /// Retorna os dados de um produto específico pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <remarks>
        /// Retorno:
        /// 
        ///     GET /api/produto/{id}
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "nome": "Produto Exemplo",
        ///         "descricao": "Descrição do produto",
        ///         "preco": 99.99,
        ///         "estoque": 10,
        ///         "categoria": {
        ///             "id": "2a8e22d5-dff9-4a3b-bc42-d02a6bfc2e63",
        ///             "nome": "Eletrônicos"
        ///         }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Retorna o produto correspondente ao ID.</response>
        /// <response code="404">Produto não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var produto = _context.Produtos
                .Where(p => p.Id == id)
                .Select(p => new
                {
                    p.Id,
                    p.Nome,
                    p.Descricao,
                    p.Preco,
                    p.Estoque,
                    Categoria = new { p.Categoria.Id, p.Categoria.Nome }
                })
                .SingleOrDefault();

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        /// <summary>
        /// Cadastra um novo produto.
        /// </summary>
        /// <param name="dto">Dados do produto.</param>
        /// <param name="categoriaId">ID da categoria associada ao produto.</param>
        /// <remarks>
        /// Entrada:
        /// 
        ///     POST
        ///     {
        ///         "nome": "Produto Exemplo",
        ///         "descricao": "Descrição do produto",
        ///         "preco": 99.99,
        ///         "estoque": 10
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Produto criado com sucesso.</response>
        /// <response code="400">Erro nos dados fornecidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(ProdutoDTO dto, Guid categoriaId)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.Id == categoriaId);
            if (categoria == null)
            {
                return BadRequest("Categoria não encontrada.");
            }

            var produto = new Produto
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Descricao = dto.Descricao,
                Preco = dto.Preco,
                Estoque = dto.Estoque,
                Categoria = categoria
            };

            _context.Produtos.Add(produto);

            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        /// <summary>
        /// Atualiza os dados de um produto existente.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <param name="input">Dados atualizados do produto.</param>
        /// <param name="categoriaId">ID da categoria relativa a aquele produto.</param>
        /// <remarks>
        /// Entrada:
        /// 
        ///     PUT
        ///     {
        ///         "nome": "Produto Atualizado",
        ///         "descricao": "Nova descrição",
        ///         "preco": 149.99,
        ///         "estoque": 20
        ///     }
        ///     
        /// </remarks>
        /// <response code="204">Produto atualizado com sucesso.</response>
        /// <response code="404">Produto não encontrado.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(Guid id, ProdutoDTO input, Guid categoriaId)
        {
            var produto = _context.Produtos.SingleOrDefault(p => p.Id == id);
            if (produto == null)
            {
                return NotFound();
            }

            var categoria = _context.Categorias.SingleOrDefault(c => c.Id == categoriaId);
            if (categoria == null)
            {
                return BadRequest("Categoria não encontrada.");
            }


            produto.Update(input.Nome, input.Descricao, input.Preco, input.Estoque);
            produto.Categoria = categoria;

            return NoContent();
        }

        /// <summary>
        /// Exclui um produto pelo ID.
        /// </summary>
        /// <param name="id">ID do produto.</param>
        /// <response code="204">Produto excluído com sucesso.</response>
        /// <response code="404">Produto não encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

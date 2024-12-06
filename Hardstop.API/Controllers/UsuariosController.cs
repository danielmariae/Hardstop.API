using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hardstop.API.Controllers
{
    /// <summary>
    /// Controller responsável por usuários e favoritos de um usuário.
    /// </summary>
    [Route("api/usuario")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly HardstopDbContext _context;

        /// <summary>
        /// Inicializa o controller com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public UsuariosController(HardstopDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtém todos os usuários cadastrados.
        /// </summary>
        /// <remarks>
        /// Retorno:
        ///     
        ///     GET /api/usuario
        ///     [
        ///         {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "nome": "João",
        ///             "email": "joao@email.com",
        ///             "senha": "123456"
        ///         }
        ///     ]
        /// </remarks>
        /// <response code="200">Retorna a lista de usuários cadastrados</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var users = _context.Usuarios.ToList();
            return Ok(users);
        }

        /// <summary>
        /// Obtém um usuário específico pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <remarks>
        /// Retorno:
        ///     
        ///     GET /api/usuario/{id}
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "nome": "João",
        ///         "email": "joao@email.com",
        ///         "senha": "123456"
        ///     }
        /// </remarks>
        /// <response code="200">Retorna o usuário correspondente ao ID</response>
        /// <response code="404">Se o usuário não for encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(d => d.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados do novo usuário</param>
        /// <remarks>
        /// Exemplo de entrada:
        ///     
        ///     POST /api/usuario
        ///     {
        ///         "nome": "João",
        ///         "email": "joao@email.com",
        ///         "senha": "123456"
        ///     }
        /// </remarks>
        /// <response code="201">Usuário criado com sucesso</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult Post(UsuarioDTO dto)
        {
            var usuario = new Usuario(
                Guid.NewGuid(),
                dto.Nome,
                dto.Email,
                dto.Senha
            );

            _context.Usuarios.Add(usuario);
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }

        /// <summary>
        /// Atualiza os dados de um usuário específico.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="input">Dados atualizados do usuário</param>
        /// <response code="204">Usuário atualizado com sucesso</response>
        /// <response code="404">Se o usuário não for encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Exclui um usuário pelo ID.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <response code="204">Usuário excluído com sucesso</response>
        /// <response code="404">Se o usuário não for encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            var usuario = _context.Usuarios.SingleOrDefault(d => d.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            return NoContent();
        }

        /// <summary>
        /// Adiciona um produto à lista de favoritos de um usuário.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="produto">Objeto do produto</param>
        /// <response code="204">Produto adicionado aos favoritos</response>
        /// <response code="404">Se o usuário não for encontrado</response>
        [HttpPost("{id}/favoritos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        /// <summary>
        /// Remove um produto da lista de favoritos de um usuário.
        /// </summary>
        /// <param name="id">ID do usuário</param>
        /// <param name="produto">Objeto do produto</param>
        /// <response code="204">Produto removido dos favoritos</response>
        /// <response code="404">Se o usuário não for encontrado</response>
        [HttpDelete("{id}/favoritos")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

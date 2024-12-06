using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hardstop.API.Controllers
{
    /// <summary>
    /// Controller responsável por gerenciar pedidos, carrinhos, itens de carrinho e pagamentos relativos a pedidos.
    /// </summary>
    [Route("api/pedido")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly HardstopDbContext _context;

        /// <summary>
        /// Inicializa o controller com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados.</param>
        public PedidosController(HardstopDbContext context)
        {
            _context = context;
        }

        // Obter todos os pedidos
        /// <summary>
        /// Retorna a lista de todos os pedidos cadastrados.
        /// </summary>
        /// <remarks>
        /// Exemplo de resposta:
        /// 
        ///     GET
        ///     api/pedido
        ///     [
        ///         {
        ///             "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///             "horarioPedido": "2024-12-06T14:30:00Z",
        ///             "statusPedido": 1,
        ///             "usuarioId": "2bdf85f8-1234-4321-b3fc-2c963f66afa6",
        ///             "carrinho": {
        ///                 "id": "4ab25d6f-789a-4562-b3fc-2c963f66afa6",
        ///                 "dataCriacao": "2024-12-05T12:00:00Z",
        ///                 "items": [
        ///                     {
        ///                         "produtoId": "5fa12c44-5717-4562-b3fc-2c963f66afa6",
        ///                         "quantidadeProduto": 2,
        ///                         "precoUnitario": 49.99
        ///                     }
        ///                 ]
        ///             },
        ///             "pagamento": {
        ///                 "id": "7fa12c44-1234-4321-b3fc-2c963f66afa6",
        ///                 "formaPagamento": "Cartão de Crédito",
        ///                 "dataHoraPagamento": "2024-12-06T14:00:00Z",
        ///                 "valorPagamento": 99.98,
        ///                 "validacaoPagamento": true
        ///             }
        ///         }
        ///     ]
        ///     
        /// </remarks>
        /// <response code="200">Retorna a lista de pedidos.</response>
        [HttpGet]
        public IActionResult GetAll()
        {
            var pedidos = _context.Pedidos.ToList();
            return Ok(pedidos);
        }

        // Obter pedido pelo ID
        /// <summary>
        /// Retorna os detalhes de um pedido específico pelo ID.
        /// </summary>
        /// <param name="id">ID do pedido.</param>
        /// <remarks>
        /// Exemplo de resposta:
        /// 
        ///     GET
        ///     api/pedido/{id}
        ///     {
        ///         "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///         "horarioPedido": "2024-12-06T14:30:00Z",
        ///         "statusPedido": 1,
        ///         "usuarioId": "2bdf85f8-1234-4321-b3fc-2c963f66afa6",
        ///         "carrinho": {
        ///             "id": "4ab25d6f-789a-4562-b3fc-2c963f66afa6",
        ///             "dataCriacao": "2024-12-05T12:00:00Z",
        ///             "items": [
        ///                 {
        ///                     "produtoId": "5fa12c44-5717-4562-b3fc-2c963f66afa6",
        ///                     "quantidadeProduto": 2,
        ///                     "precoUnitario": 49.99
        ///                 }
        ///             ]
        ///         },
        ///         "pagamento": {
        ///             "id": "7fa12c44-1234-4321-b3fc-2c963f66afa6",
        ///             "formaPagamento": "Cartão de Crédito",
        ///             "dataHoraPagamento": "2024-12-06T14:00:00Z",
        ///             "valorPagamento": 99.98,
        ///             "validacaoPagamento": true
        ///         }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Retorna o pedido correspondente ao ID.</response>
        /// <response code="404">Pedido não encontrado.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(Guid id)
        {
            var pedido = _context.Pedidos.SingleOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            return Ok(pedido);
        }

        // Criar um novo pedido para um usuário
        /// <summary>
        /// Cria um novo pedido para um usuário.
        /// </summary>
        /// <param name="usuarioId">ID do usuário associado ao pedido.</param>
        /// <param name="pedidoDto">Dados do pedido.</param>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     POST
        ///     {
        ///         "horarioPedido": "2024-12-06T14:30:00Z",
        ///         "statusPedido": 0,
        ///         "carrinho": {
        ///             "items": [
        ///                 {
        ///                     "produtoId": "5fa12c44-5717-4562-b3fc-2c963f66afa6",
        ///                     "quantidadeProduto": 2,
        ///                     "precoUnitario": 49.99
        ///                 }
        ///             ]
        ///         },
        ///         "pagamento": {
        ///             "formaPagamento": "Cartão de Crédito",
        ///             "dataHoraPagamento": "2024-12-06T14:00:00Z",
        ///             "valorPagamento": 99.98,
        ///             "validacaoPagamento": true
        ///         }
        ///     }
        ///     
        /// </remarks>
        /// <response code="201">Pedido criado com sucesso.</response>
        /// <response code="404">Usuário ou produto não encontrado.</response>
        /// <response code="400">Erro nos dados enviados.</response>
        [HttpPost("{usuarioId}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Guid usuarioId, PedidoDTO pedidoDto)
        {
            // Verificar se o usuário existe
            var usuario = _context.Usuarios.SingleOrDefault(u => u.Id == usuarioId);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // Criar o carrinho associado ao pedido
            var carrinho = new Carrinho();

            // Adicionar itens ao carrinho
            foreach (var itemDto in pedidoDto.Carrinho.Items)
            {
                var produto = _context.Produtos.SingleOrDefault(p => p.Id == itemDto.ProdutoId);
                if (produto == null)
                {
                    return BadRequest($"Produto com ID {itemDto.ProdutoId} não encontrado.");
                }

                var itemCarrinho = new ItemCarrinho(
                    itemDto.QuantidadeProduto,
                    itemDto.PrecoUnitario,
                    produto
                );
                carrinho.Items.Add(itemCarrinho);
            }

            // Criar o pagamento associado ao pedido
            var pagamento = new Pagamento
            {
                Id = Guid.NewGuid(),
                FormaPagamento = pedidoDto.Pagamento.FormaPagamento,
                DataHoraPagamento = pedidoDto.Pagamento.DataHoraPagamento,
                ValorPagamento = pedidoDto.Pagamento.ValorPagamento,
                ValidacaoPagamento = pedidoDto.Pagamento.ValidacaoPagamento
            };

            // Criar o pedido
            var pedido = new Pedido(
                Guid.NewGuid(),
                pedidoDto.HorarioPedido,
                pedidoDto.StatusPedido,
                usuarioId,
                carrinho,
                pagamento
            );

            // Associar o pedido ao usuário
            usuario.Pedidos.Add(pedido);

            // Adicionar o pedido, carrinho e pagamento às listas no contexto
            _context.Pedidos.Add(pedido);
            _context.Carrinhos.Add(carrinho);
            _context.Pagamentos.Add(pagamento);

            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        /// <summary>
        /// Atualiza os dados de um pedido específico pelo ID.
        /// </summary>
        /// <param name="id">ID do pedido a ser atualizado.</param>
        /// <param name="pedidoDto">Dados atualizados do pedido.</param>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     PUT
        ///     {
        ///         "horarioPedido": "2024-12-06T16:00:00Z",
        ///         "statusPedido": 2,
        ///         "carrinho": {
        ///             "items": [
        ///                 {
        ///                     "produtoId": "5fa12c44-5717-4562-b3fc-2c963f66afa6",
        ///                     "quantidadeProduto": 3,
        ///                     "precoUnitario": 49.99
        ///                 }
        ///             ]
        ///         },
        ///         "pagamento": {
        ///             "formaPagamento": "Pix",
        ///             "dataHoraPagamento": "2024-12-06T15:30:00Z",
        ///             "valorPagamento": 149.97,
        ///             "validacaoPagamento": true
        ///         }
        ///     }
        ///     
        /// </remarks>
        /// <response code="200">Pedido atualizado com sucesso.</response>
        /// <response code="404">Pedido não encontrado.</response>
        /// <response code="400">Erro nos dados enviados.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(Guid id, PedidoDTO pedidoDto)
        {
            // Localizar o pedido pelo ID
            var pedido = _context.Pedidos.SingleOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            // Atualizar o carrinho
            var carrinho = pedido.Carrinho;
            carrinho.Items.Clear();

            foreach (var itemDto in pedidoDto.Carrinho.Items)
            {
                var produto = _context.Produtos.SingleOrDefault(p => p.Id == itemDto.ProdutoId);
                if (produto == null)
                {
                    return BadRequest($"Produto com ID {itemDto.ProdutoId} não encontrado.");
                }

                var itemCarrinho = new ItemCarrinho(
                    itemDto.QuantidadeProduto,
                    itemDto.PrecoUnitario,
                    produto
                );
                carrinho.Items.Add(itemCarrinho);
            }

            // Atualizar o pagamento
            var pagamento = pedido.Pagamento;
            pagamento.Update(
                pedidoDto.Pagamento.FormaPagamento,
                pedidoDto.Pagamento.DataHoraPagamento,
                pedidoDto.Pagamento.ValorPagamento,
                pedidoDto.Pagamento.ValidacaoPagamento
            );

            // Atualizar o pedido
            pedido.Update(
                pedidoDto.HorarioPedido,
                pedidoDto.StatusPedido,
                carrinho,
                pagamento
            );

            return Ok("Pedido atualizado com sucesso.");
        }

        /// <summary>
        /// Remove um pedido específico pelo ID.
        /// </summary>
        /// <param name="id">ID do pedido a ser removido.</param>
        /// <remarks>
        /// Exemplo de requisição:
        /// 
        ///     DELETE /api/pedido/{id}
        /// 
        ///     Resposta esperada:
        ///     Pedido removido com sucesso.
        /// 
        /// </remarks>
        /// <response code="200">Pedido removido com sucesso.</response>
        /// <response code="404">Pedido não encontrado.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(Guid id)
        {
            // Localizar o pedido pelo ID
            var pedido = _context.Pedidos.SingleOrDefault(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound("Pedido não encontrado.");
            }

            // Remover o pedido, carrinho e pagamento do contexto
            _context.Pedidos.Remove(pedido);
            _context.Carrinhos.Remove(pedido.Carrinho);
            _context.Pagamentos.Remove(pedido.Pagamento);

            return Ok("Pedido excluído com sucesso.");
        }
    }
}

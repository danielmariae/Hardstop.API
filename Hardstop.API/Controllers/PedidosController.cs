using Hardstop.API.Entities;
using Hardstop.API.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Hardstop.API.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly HardstopDbContext _context;

        public PedidosController(HardstopDbContext context)
        {
            _context = context;
        }

        // Obter pedido pelo ID
        [HttpGet]
        public IActionResult GetAll()
        {
            var pedidos = _context.Pedidos.ToList();
            return Ok(pedidos);
        }

        // Obter pedido pelo ID
        [HttpGet("{id}")]
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
        [HttpPost("{usuarioId}")]
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

        [HttpPut("{id}")]
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

        [HttpDelete("{id}")]
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

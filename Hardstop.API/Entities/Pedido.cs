using Hardstop.API.Entities;

namespace Hardstop.API.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public DateTime HorarioPedido { get; set; }
        public int StatusPedido { get; set; }
        public Guid UsuarioId { get; set; }

        // Associação com Carrinho
        public Carrinho Carrinho { get; set; }

        // Associação com Pagamento
        public Pagamento Pagamento { get; set; }

        public Pedido(Guid id, DateTime horarioPedido, int statusPedido, Guid usuarioId, Carrinho carrinho, Pagamento pagamento)
        {
            Id = id;
            HorarioPedido = horarioPedido;
            StatusPedido = statusPedido;
            UsuarioId = usuarioId;
            Carrinho = carrinho;
            Pagamento = pagamento;
        }

        public void Update(DateTime horarioPedido, int statusPedido, Carrinho carrinho, Pagamento pagamento)
        {
            HorarioPedido = horarioPedido;
            StatusPedido = statusPedido;
            Carrinho = carrinho;
            Pagamento = pagamento;
        }
    }
    public class PedidoDTO
    {
        public DateTime HorarioPedido { get; set; }
        public int StatusPedido { get; set; }
        public CarrinhoDTO Carrinho { get; set; }
        public PagamentoDTO Pagamento { get; set; }
    }

    public enum StatusPedido
    {
        Pendente = 0,
        Processando = 1,
        Enviado = 2,
        Concluido = 3,
        Cancelado = 4
    }
}


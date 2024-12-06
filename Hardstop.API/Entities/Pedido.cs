using Hardstop.API.Entities;

namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa um pedido feito por um usuário.
    /// </summary>
    public class Pedido
    {
        /// <summary>
        /// Identificador único do pedido.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data e hora em que o pedido foi realizado.
        /// </summary>
        public DateTime HorarioPedido { get; set; }

        /// <summary>
        /// Status atual do pedido.
        /// </summary>
        public int StatusPedido { get; set; }

        /// <summary>
        /// Identificador do usuário que fez o pedido.
        /// </summary>
        public Guid UsuarioId { get; set; }

        /// <summary>
        /// Associação com o carrinho de compras do pedido.
        /// </summary>
        public Carrinho Carrinho { get; set; }

        /// <summary>
        /// Associação com o pagamento do pedido.
        /// </summary>
        public Pagamento Pagamento { get; set; }

        /// <summary>
        /// Construtor para criar um novo pedido.
        /// </summary>
        /// <param name="id">Identificador único do pedido.</param>
        /// <param name="horarioPedido">Data e hora do pedido.</param>
        /// <param name="statusPedido">Status do pedido.</param>
        /// <param name="usuarioId">Identificador do usuário que fez o pedido.</param>
        /// <param name="carrinho">Carrinho associado ao pedido.</param>
        /// <param name="pagamento">Pagamento associado ao pedido.</param>
        public Pedido(Guid id, DateTime horarioPedido, int statusPedido, Guid usuarioId, Carrinho carrinho, Pagamento pagamento)
        {
            Id = id;
            HorarioPedido = horarioPedido;
            StatusPedido = statusPedido;
            UsuarioId = usuarioId;
            Carrinho = carrinho;
            Pagamento = pagamento;
        }

        /// <summary>
        /// Atualiza os detalhes do pedido.
        /// </summary>
        /// <param name="horarioPedido">Nova data e hora do pedido.</param>
        /// <param name="statusPedido">Novo status do pedido.</param>
        /// <param name="carrinho">Novo carrinho associado ao pedido.</param>
        /// <param name="pagamento">Novo pagamento associado ao pedido.</param>
        public void Update(DateTime horarioPedido, int statusPedido, Carrinho carrinho, Pagamento pagamento)
        {
            HorarioPedido = horarioPedido;
            StatusPedido = statusPedido;
            Carrinho = carrinho;
            Pagamento = pagamento;
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para Pedido, usado para transferir dados entre camadas.
    /// </summary>
    public class PedidoDTO
    {
        /// <summary>
        /// Data e hora em que o pedido foi realizado.
        /// </summary>
        public DateTime HorarioPedido { get; set; }

        /// <summary>
        /// Status atual do pedido.
        /// </summary>
        public int StatusPedido { get; set; }

        /// <summary>
        /// Carrinho associado ao pedido.
        /// </summary>
        public CarrinhoDTO Carrinho { get; set; }

        /// <summary>
        /// Pagamento associado ao pedido.
        /// </summary>
        public PagamentoDTO Pagamento { get; set; }
    }

    /// <summary>
    /// Enumeração que representa os possíveis status de um pedido.
    /// </summary>
    public enum StatusPedido
    {
        /// <summary>
        /// Pedido pendente.
        /// </summary>
        Pendente = 0,

        /// <summary>
        /// Pedido está sendo processado.
        /// </summary>
        Processando = 1,

        /// <summary>
        /// Pedido foi enviado.
        /// </summary>
        Enviado = 2,

        /// <summary>
        /// Pedido foi concluído.
        /// </summary>
        Concluido = 3,

        /// <summary>
        /// Pedido foi cancelado.
        /// </summary>
        Cancelado = 4
    }
}

namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa um carrinho de compras associado a um pedido.
    /// </summary>
    public class Carrinho
    {
        /// <summary>
        /// Identificador único do carrinho.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Data e hora de criação do carrinho.
        /// </summary>
        public DateTime DataCriacao { get; set; }

        /// <summary>
        /// Lista de itens presentes no carrinho.
        /// </summary>
        public List<ItemCarrinho> Items { get; set; }

        /// <summary>
        /// Construtor padrão que inicializa o carrinho com um ID único e a data de criação atual.
        /// </summary>
        public Carrinho()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            Items = new List<ItemCarrinho>();
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para o Carrinho, usado para transferir dados entre camadas.
    /// </summary>
    public class CarrinhoDTO
    {
        /// <summary>
        /// Lista de itens presentes no carrinho.
        /// </summary>
        public List<ItemCarrinhoDTO> Items { get; set; } = new List<ItemCarrinhoDTO>();
    }
}

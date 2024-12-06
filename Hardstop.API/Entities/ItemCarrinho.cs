namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa um item no carrinho de compras.
    /// </summary>
    public class ItemCarrinho
    { 
        /// <summary>
        /// Identificador único do item no carrinho.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Quantidade do produto no carrinho.
        /// </summary>
        public int QuantidadeProduto { get; set; }
        
        /// <summary>
        /// Preço unitário do produto no carrinho.
        /// </summary>
        public decimal PrecoUnitario { get; set; }
        
        /// <summary>
        /// Produto associado ao item no carrinho.
        /// </summary>
        public Produto Produto { get; set; }
        
        /// <summary>
        /// Construtor para criar um novo item no carrinho.
        /// </summary>
        /// <param name="quantidadeProduto">Quantidade do produto.</param>
        /// <param name="precoUnitario">Preço unitário do produto.</param>
        /// <param name="produto">Produto associado.</param>
        public ItemCarrinho(int quantidadeProduto, decimal precoUnitario, Produto produto)
        {
            Id = Guid.NewGuid();
            QuantidadeProduto = quantidadeProduto;
            PrecoUnitario = precoUnitario;
            Produto = produto;
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para ItemCarrinho, usado para transferir dados entre camadas.
    /// </summary>
    public class ItemCarrinhoDTO
    {
        /// <summary>
        /// Identificador do produto.
        /// </summary>
        public Guid ProdutoId { get; set; }
        
        /// <summary>
        /// Quantidade do produto no carrinho.
        /// </summary>
        public int QuantidadeProduto { get; set; }
        
        /// <summary>
        /// Preço unitário do produto no carrinho.
        /// </summary>
        public decimal PrecoUnitario { get; set; }
    }
}

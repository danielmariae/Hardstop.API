namespace Hardstop.API.Entities
{
    public class ItemCarrinho
    { 
        public Guid Id { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Produto Produto { get; set; }
        public ItemCarrinho(int quantidadeProduto, decimal precoUnitario, Produto produto)
        {
            Id = Guid.NewGuid();
            QuantidadeProduto = quantidadeProduto;
            PrecoUnitario = precoUnitario;
            Produto = produto;
        }

    }
    public class ItemCarrinhoDTO
    {
        public Guid ProdutoId { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
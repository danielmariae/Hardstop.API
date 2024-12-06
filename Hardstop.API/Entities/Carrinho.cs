namespace Hardstop.API.Entities
{
    public class Carrinho
    {
        public Guid Id { get; set; }

        public DateTime DataCriacao { get; set; }
        public List<ItemCarrinho> Items { get; set; }

        public Carrinho()
        {
            Id = Guid.NewGuid();
            DataCriacao = DateTime.UtcNow;
            Items = new List<ItemCarrinho>();
        }
    }
    public class CarrinhoDTO
    {
        public List<ItemCarrinhoDTO> Items { get; set; } = new List<ItemCarrinhoDTO>();
    }
}
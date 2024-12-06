namespace Hardstop.API.Entities
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco {  get; set; }
        public int Estoque { get; set; }
        public Categoria Categoria { get; set; }

        public void Update(string nome, string descricao, decimal preco, int estoque)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }
    }
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
    }
}
namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa um produto disponível na loja.
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Identificador único do produto.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Quantidade de estoque disponível do produto.
        /// </summary>
        public int Estoque { get; set; }

        /// <summary>
        /// Categoria à qual o produto pertence.
        /// </summary>
        public Categoria Categoria { get; set; }

        /// <summary>
        /// Atualiza os detalhes do produto.
        /// </summary>
        /// <param name="nome">Novo nome do produto.</param>
        /// <param name="descricao">Nova descrição do produto.</param>
        /// <param name="preco">Novo preço do produto.</param>
        /// <param name="estoque">Nova quantidade de estoque do produto.</param>
        public void Update(string nome, string descricao, decimal preco, int estoque)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Estoque = estoque;
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para Produto, usado para transferir dados entre camadas.
    /// </summary>
    public class ProdutoDTO
    {
        /// <summary>
        /// Nome do produto.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do produto.
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Preço do produto.
        /// </summary>
        public decimal Preco { get; set; }

        /// <summary>
        /// Quantidade de estoque disponível do produto.
        /// </summary>
        public int Estoque { get; set; }
    }
}

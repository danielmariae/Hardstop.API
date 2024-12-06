namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa uma categoria de produtos.
    /// </summary>
    public class Categoria
    {
        /// <summary>
        /// Construtor para criar uma nova categoria.
        /// </summary>
        /// <param name="id">Identificador único da categoria.</param>
        /// <param name="nome">Nome da categoria.</param>
        public Categoria(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        /// <summary>
        /// Identificador único da categoria.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Nome da categoria.
        /// </summary>
        public string Nome { get; set; }
        
        /// <summary>
        /// Atualiza o nome da categoria.
        /// </summary>
        /// <param name="nome">Novo nome da categoria.</param>
        public void Update(string nome)
        {
            Nome = nome;
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para Categoria, usado para transferir dados entre camadas.
    /// </summary>
    public class CategoriaDTO
    {
        /// <summary>
        /// Nome da categoria.
        /// </summary>
        public string Nome { get; set; }
    }
}
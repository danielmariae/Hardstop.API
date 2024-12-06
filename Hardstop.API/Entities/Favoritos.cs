using System.Security.Cryptography.X509Certificates;

namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa a lista de produtos favoritos de um usuário.
    /// </summary>
    public class Favoritos
    {
        /// <summary>
        /// Identificador único dos favoritos.
        /// </summary>
        public Guid Id { get; set; }
        
        /// <summary>
        /// Lista de produtos favoritos.
        /// </summary>
        public List<Produto> Produtos { get; set; }
        
        /// <summary>
        /// Construtor padrão que inicializa a lista de produtos favoritos.
        /// </summary>
        public Favoritos()
        {
            Produtos = new List<Produto>();
        }
    }
}

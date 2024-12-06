using System.Security.Cryptography.X509Certificates;

namespace Hardstop.API.Entities
{
    public class Favoritos
    {
        public Guid Id { get; set; }
        public List<Produto> Produtos { get; set; }
        
        public Favoritos()
        {
            Produtos = new List<Produto>();
        }
    }
}
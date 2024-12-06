using Hardstop.API.Entities;
using System.Collections.Generic;

namespace Hardstop.API.Persistence
{
    /// <summary>
    /// Contexto do banco de dados simulado para a aplicação Hardstop.
    /// </summary>
    public class HardstopDbContext
    {
        /// <summary>
        /// Lista de usuários no sistema.
        /// </summary>
        public List<Usuario> Usuarios { get; set; }
        
        /// <summary>
        /// Lista de produtos disponíveis no sistema.
        /// </summary>
        public List<Produto> Produtos { get; set; }
        
        /// <summary>
        /// Lista de categorias disponíveis no sistema.
        /// </summary>
        public List<Categoria> Categorias { get; set; }
        
        /// <summary>
        /// Lista de favoritos dos usuários no sistema.
        /// </summary>
        public List<Favoritos> Favoritos { get; set; }
        
        /// <summary>
        /// Lista de pedidos feitos pelos usuários no sistema.
        /// </summary>
        public List<Pedido> Pedidos { get; set; }
        
        /// <summary>
        /// Lista de carrinhos de compras dos usuários no sistema.
        /// </summary>
        public List<Carrinho> Carrinhos { get; set; }
        
        /// <summary>
        /// Lista de itens presentes nos carrinhos de compras dos usuários.
        /// </summary>
        public List<ItemCarrinho> ItensCarrinho { get; set; }
        
        /// <summary>
        /// Lista de pagamentos realizados pelos usuários no sistema.
        /// </summary>
        public List<Pagamento> Pagamentos { get; set; }

        /// <summary>
        /// Construtor que inicializa as listas do banco de dados simulado.
        /// </summary>
        public HardstopDbContext()
        {
            Usuarios = new List<Usuario>();
            Produtos = new List<Produto>();
            Categorias = new List<Categoria>();
            Favoritos = new List<Favoritos>();
            Pedidos = new List<Pedido>();
            Carrinhos = new List<Carrinho>();
            ItensCarrinho = new List<ItemCarrinho>();
            Pagamentos = new List<Pagamento>();
        }
    }
}

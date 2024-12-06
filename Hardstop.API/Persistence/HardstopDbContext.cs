
using Hardstop.API.Entities;
using System.Collections.Generic;

namespace Hardstop.API.Persistence
{
    public class HardstopDbContext
        {
            // Listas que simulam tabelas no banco de dados
            public List<Usuario> Usuarios { get; set; }
            public List<Produto> Produtos { get; set; }
            public List<Categoria> Categorias { get; set; }
            public List<Favoritos> Favoritos { get; set; }
            public List<Pedido> Pedidos { get; set; }
            public List<Carrinho> Carrinhos { get; set; }
            public List<ItemCarrinho> ItensCarrinho { get; set; }
            public List<Pagamento> Pagamentos { get; set; }

            // Construtor privado para inicializar as listas
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

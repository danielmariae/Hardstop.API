using Hardstop.API.Entities;
using System;
using System.Collections.Generic;

namespace Hardstop.API.Persistence
{
    public static class DataInitializer
    {
        public static void Seed(HardstopDbContext context)
        {
            // Adicionando usuários
            var usuarios = new List<Usuario>
            {
                new Usuario(Guid.NewGuid(), "Alice", "alice@example.com", "password123"),
                new Usuario(Guid.NewGuid(), "Bob", "bob@example.com", "password456")
            };
            context.Usuarios.AddRange(usuarios);

            // Adicionando categorias
            var categorias = new List<Categoria>
            {
                new Categoria(Guid.NewGuid(), "Categoria 1"),
                new Categoria(Guid.NewGuid(), "Categoria 2")
            };
            context.Categorias.AddRange(categorias);

            // Adicionando produtos
            var produtos = new List<Produto>
            {
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Produto A",
                    Descricao = "Descrição do Produto A",
                    Preco = 100.0m,
                    Estoque = 50,
                    Categoria = categorias[0] // Associa ao objeto Categoria já criado
                },
                new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = "Produto B",
                    Descricao = "Descrição do Produto B",
                    Preco = 200.0m,
                    Estoque = 30,
                    Categoria = categorias[1] // Associa ao objeto Categoria já criado
                }
            };
            context.Produtos.AddRange(produtos);

            // Adicionando pedidos
            var carrinho = new Carrinho
            {
                Items = new List<ItemCarrinho>
                {
                    new ItemCarrinho(1, 100.0m, produtos[0])
                }
            };

            var pagamento = new Pagamento
            {
                Id = Guid.NewGuid(),
                FormaPagamento = "Cartão de Crédito",
                DataHoraPagamento = DateTime.UtcNow,
                ValorPagamento = 100.0m,
                ValidacaoPagamento = true
            };

            var pedido = new Pedido(
                Guid.NewGuid(),
                DateTime.UtcNow,
                (int)StatusPedido.Pendente,
                usuarios[0].Id,
                carrinho,
                pagamento
            );

            context.Pedidos.Add(pedido);
            context.Carrinhos.Add(carrinho);
            context.Pagamentos.Add(pagamento);
        }
    }
}

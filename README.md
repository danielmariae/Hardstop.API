# Hardstop.API

## Descrição
Este projeto é uma API para gerenciar usuários, produtos, categorias, pedidos e carrinhos de compras. Ele usa o ASP.NET Core para construir a API e Entity Framework para gerenciar o acesso aos dados.

## Estrutura do Projeto

### Classes Principais

#### Usuario
- **Propriedades**: 
  - `Id` (Guid)
  - `Nome` (string)
  - `Email` (string)
  - `Senha` (string)
  - `Favoritos` (Favoritos)
  - `Pedidos` (List<Pedido>)

#### Produto
- **Propriedades**:
  - `Id` (Guid)
  - `Nome` (string)
  - `Descricao` (string)
  - `Preco` (decimal)
  - `Estoque` (int)
  - `Categoria` (Categoria)

#### Categoria
- **Propriedades**:
  - `Id` (Guid)
  - `Nome` (string)

#### Pedido
- **Propriedades**:
  - `Id` (Guid)
  - `HorarioPedido` (DateTime)
  - `StatusPedido` (int)
  - `UsuarioId` (Guid)
  - `Carrinho` (Carrinho)
  - `Pagamento` (Pagamento)

#### Carrinho
- **Propriedades**:
  - `Id` (Guid)
  - `DataCriacao` (DateTime)
  - `Items` (List<ItemCarrinho>)

#### ItemCarrinho
- **Propriedades**:
  - `Id` (Guid)
  - `QuantidadeProduto` (int)
  - `PrecoUnitario` (decimal)
  - `Produto` (Produto)

#### Pagamento
- **Propriedades**:
  - `Id` (Guid)
  - `FormaPagamento` (string)
  - `DataHoraPagamento` (DateTime)
  - `ValorPagamento` (decimal)
  - `ValidacaoPagamento` (bool)

### Relacionamentos

- **Usuario** tem muitos **Pedidos**
- **Pedido** tem um **Carrinho**
- **Pedido** tem um **Pagamento**
- **Carrinho** tem muitos **ItemCarrinho**
- **ItemCarrinho** tem um **Produto**
- **Produto** tem uma **Categoria**

### Fluxo de Uso do Sistema

1. **Usuários**: Os usuários podem ser criados, atualizados, deletados e listados. Cada usuário pode ter múltiplos pedidos.
2. **Produtos**: Os produtos podem ser adicionados, atualizados, deletados e listados. Cada produto pertence a uma categoria.
3. **Categorias**: As categorias são usadas para classificar os produtos.
4. **Pedidos**: Os pedidos contêm informações sobre os produtos que o usuário comprou, incluindo o carrinho e o pagamento.
5. **Carrinho**: O carrinho contém os itens que um usuário adicionou para compra.
6. **Pagamento**: As informações de pagamento são associadas a um pedido.

### Pré-requisitos

- .NET 8.0 SDK
- IDE (Visual Studio, Visual Studio Code, etc.)

### Como Executar

1. **Clone o repositório**:
   ```sh
   git clone https://github.com/seu-usuario/hardstop-api.git
   cd hardstop-api
   ```

2. **Instale as dependências**:
   Certifique-se de que você tem o .NET 8.0 SDK instalado. Para instalar as dependências, use o comando:
   ```sh
   dotnet restore
   ```

3. **Configure o banco de dados**:
   Modifique o `HardstopDbContext` conforme necessário para apontar para seu banco de dados. Use o `DataInitializer` para inicializar o banco de dados com dados de exemplo.

4. **Execute a aplicação**:
   ```sh
   dotnet run
   ```

5. **Acesse a API**:
   A API estará disponível em `http://localhost:5000` ou `https://localhost:5001`. Use ferramentas como Postman ou Insomnia para testar os endpoints da API.

### Endpoints Principais

- **Usuarios**:
  - `GET /api/usuario`
  - `GET /api/usuario/{id}`
  - `POST /api/usuario`
  - `PUT /api/usuario/{id}`
  - `DELETE /api/usuario/{id}`

- **Produtos**:
  - `GET /api/produto`
  - `GET /api/produto/{id}`
  - `POST /api/produto`
  - `PUT /api/produto/{id}`
  - `DELETE /api/produto/{id}`
  - `POST /api/usuario/{id}/favoritos` - Adiciona um produto à lista de favoritos de um usuário
  - `DELETE /api/usuario/{id}/favoritos` - Remove um produto da lista de favoritos de um usuário

- **Categorias**:
  - `GET /api/categoria`
  - `GET /api/categoria/{id}`
  - `POST /api/categoria`
  - `PUT /api/categoria/{id}`
  - `DELETE /api/categoria/{id}`

- **Pedidos**:
  - `GET /api/pedido`
  - `GET /api/pedido/{id}`
  - `POST /api/pedido`
  - `PUT /api/pedido/{id}`
  - `DELETE /api/pedido/{id}`

## Contribuições

Sinta-se à vontade para contribuir com este projeto. Envie um pull request com melhorias e correções.

## Licença

Este projeto está licenciado sob a Licença MIT. Veja o arquivo [LICENSE](LICENSE.txt) para mais detalhes.

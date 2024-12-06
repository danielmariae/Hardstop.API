using System.Security.Cryptography.X509Certificates;

namespace Hardstop.API.Entities
{
    /// <summary>
    /// Representa um usuário no sistema.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Senha { get; set; }

        /// <summary>
        /// Lista de produtos favoritos do usuário.
        /// </summary>
        public Favoritos Favoritos { get; set; }

        /// <summary>
        /// Lista de pedidos feitos pelo usuário.
        /// </summary>
        public List<Pedido> Pedidos { get; set; }

        /// <summary>
        /// Construtor para criar um novo usuário.
        /// </summary>
        /// <param name="id">Identificador único do usuário.</param>
        /// <param name="nome">Nome do usuário.</param>
        /// <param name="email">Email do usuário.</param>
        /// <param name="senha">Senha do usuário.</param>
        public Usuario(Guid id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Pedidos = new List<Pedido>();
            Favoritos = new Favoritos();
        }

        /// <summary>
        /// Atualiza os detalhes do usuário.
        /// </summary>
        /// <param name="nome">Novo nome do usuário.</param>
        /// <param name="email">Novo email do usuário.</param>
        /// <param name="senha">Nova senha do usuário.</param>
        public void Update(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }

    /// <summary>
    /// Data Transfer Object (DTO) para Usuario, usado para transferir dados entre camadas.
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public string Senha { get; set; }
    }
}

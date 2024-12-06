using System.Security.Cryptography.X509Certificates;

namespace Hardstop.API.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; } // Identificador único do usuário
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } // Enum para definir o tipo do usuário
        public Favoritos Favoritos { get; set; }
        public List<Pedido> Pedidos { get; set; }

        public Usuario(Guid id, string nome, string email, string senha)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Pedidos = new List<Pedido>();
            Favoritos = new Favoritos();
        }

        public void Update(string nome, string email, string senha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
        }
    }

    public class UsuarioDTO
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; } // Enum para definir o tipo do usuário
    }
}

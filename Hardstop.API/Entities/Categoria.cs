namespace Hardstop.API.Entities
{
    public class Categoria
    {
        public Categoria(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public void Update (string nome)
        {
            Nome = nome;
        }
    }
    public class CategoriaDTO
    {
        public string Nome { get; set; }
    }
}
using GerenciadorDeLivraria.Dtos;

namespace GerenciadorDeLivraria.Entities
{
    public class LivroResponse
    {
        public Guid Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Genero { get; set; }
        public double? Preco { get; set; }
        public int? Quantidade { get; set; }
    }
}

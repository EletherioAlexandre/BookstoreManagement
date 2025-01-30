using GerenciadorDeLivraria.Enums;

namespace GerenciadorDeLivraria.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public Genero Genero { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}

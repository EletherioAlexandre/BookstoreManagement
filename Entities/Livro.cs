using System.Text.Json.Serialization;
using GerenciadorDeLivraria.Enums;

namespace GerenciadorDeLivraria.Models
{
    public class Livro
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
    }
}

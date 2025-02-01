using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Interfaces
{
    public interface ILivrariaService
    {
        ApiResponse<List<Livro>> GetAllBooks();
        void DeleteBook(int id);
        void InsertBook(Livro livro);
        void UpdateBook(int id);

    }
}

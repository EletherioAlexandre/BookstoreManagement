using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Interfaces
{
    public interface ILivrariaService
    {
        Task<ApiResponse<List<Livro>>> GetAllBooks();
        Task<ApiResponse> DeleteBook(int id);
        Task<ApiResponse> InsertBook(Livro livro);
        Task<ApiResponse> UpdateBook(int id);

    }
}

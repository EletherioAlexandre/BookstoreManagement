using GerenciadorDeLivraria.Dtos;
using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Interfaces
{
    public interface ILivrariaService
    {
        Task<ApiResponse<List<LivroResponse>>> GetAllBooks();
        Task<ApiResponse> DeleteBook(Guid id);
        Task<ApiResponse> UpdateBook(int id);
        Task<ApiResponse<LivroResponse>> InsertBook(LivroRequestDto livro);
    }
}

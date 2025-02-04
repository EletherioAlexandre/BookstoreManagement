using GerenciadorDeLivraria.Dtos;
using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Interfaces
{
    public interface ILivrariaService
    {
        Task<ApiResponse<List<LivroResponse>>> GetAllBooks();
        Task<ApiResponse<LivroResponse>> DeleteBook(Guid id);
        Task<ApiResponse<LivroResponse>> UpdateBook(Guid id, LivroRequestDto request);
        Task<ApiResponse<LivroResponse>> InsertBook(LivroRequestDto livro);
    }
}

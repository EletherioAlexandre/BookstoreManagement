using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Enums;
using GerenciadorDeLivraria.Helper;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Services
{
    public class LivrariaService : ILivrariaService
    {
        private readonly IBaseRepository<Livro> _repository;

        public LivrariaService(IBaseRepository<Livro> repository)
        {
            _repository = repository;
        }
        public ApiResponse<List<Livro>> GetAllBooks()
        {
            try
            {
                List<Livro> livros = _repository.Get();

                if (livros.Count == 0 || livros == null)
                {
                    return ApiResponseHelper.CreateResponse<List<Livro>>(
                        default,
                        StatusCode.NotFound,
                        "Books not found."
                    );
                }

                return ApiResponseHelper.CreateResponse<List<Livro>>(
                    livros,
                    StatusCode.Success
                );
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.CreateErrorResponse<List<Livro>>(
                    new List<string> { ex.Message },
                    StatusCode.InternalServerError
                    );
            }

        }
        public void DeleteBook(int id)
        {
            throw new NotImplementedException();
        }


        public void InsertBook(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}

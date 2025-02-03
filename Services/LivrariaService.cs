using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Enums;
using GerenciadorDeLivraria.Helper;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
using Microsoft.Data.SqlClient;

namespace GerenciadorDeLivraria.Services
{
    public class LivrariaService : ILivrariaService
    {
        private readonly IBaseRepository<Livro> _repository;

        public LivrariaService(IBaseRepository<Livro> repository)
        {
            _repository = repository;
        }
        async public Task<ApiResponse<List<Livro>>> GetAllBooks()
        {
            try
            {
                List<Livro> livros = await _repository.GetAsync();

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
        public Task<ApiResponse> DeleteBook(int id)
        {
            throw new NotImplementedException();
        }


        public async Task<ApiResponse> InsertBook(Livro livro)
        {
            try
            {
                if (livro == null)
                {
                    return ApiResponseHelper.CreateResponse<Livro>(
                           livro,
                           StatusCode.BadRequest
                        );
                }

                if (string.IsNullOrWhiteSpace(livro.Titulo))
                {
                    return ApiResponseHelper.CreateErrorResponse<Livro>(
                        new List<string> { "Title is required." },
                        StatusCode.BadRequest
                    );
                }

                if (string.IsNullOrWhiteSpace(livro.Autor))
                {
                    return ApiResponseHelper.CreateErrorResponse<Livro>(
                        new List<string> { "Author is required." },
                        StatusCode.BadRequest
                    );
                }

                if (livro.Preco <= 0)
                {
                    return ApiResponseHelper.CreateErrorResponse<Livro>(
                        new List<string> { "Price must be greater than zero." },
                        StatusCode.BadRequest
                    );
                }

                if (livro.Quantidade < 0)
                {
                    return ApiResponseHelper.CreateErrorResponse<Livro>(
                        new List<string> { "Quantity may not be less than 0." },
                        StatusCode.BadRequest
                    );
                }

                if (livro.Id == Guid.Empty)
                {
                    livro.Id = Guid.NewGuid();
                }


                return ApiResponseHelper.CreateResponse<Livro>(
                        livro,
                        StatusCode.Created
                    );

            }
            catch (SqlException ex)
            {
                return ApiResponseHelper.CreateErrorResponse<Livro>(
                    new List<string> { $"Database error: {ex.Message}" },
                    StatusCode.InternalServerError
                    );
            }

            catch (Exception ex)
            {
                return ApiResponseHelper.CreateErrorResponse<Livro>(
                    new List<string> { $"Unexpected error: {ex.Message}" },
                    StatusCode.InternalServerError
                    );
            }

        }

        public Task<ApiResponse> UpdateBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}

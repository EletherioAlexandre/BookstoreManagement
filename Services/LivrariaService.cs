using GerenciadorDeLivraria.Dtos;
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
        private readonly IBaseRepository<LivroRequestDto, LivroResponse> _repository;

        public LivrariaService(IBaseRepository<LivroRequestDto, LivroResponse> repository)
        {
            _repository = repository;
        }
        async public Task<ApiResponse<List<LivroResponse>>> GetAllBooks()
        {
            try
            {
                List<LivroResponse> livros = await _repository.GetAsync();

                if (livros.Count == 0 || livros == null)
                {
                    return ApiResponseHelper.CreateResponse<List<LivroResponse>>(
                        default,
                        StatusCode.NotFound,
                        "Books not found."
                    );
                }

                return ApiResponseHelper.CreateResponse<List<LivroResponse>>(
                    livros,
                    StatusCode.Success
                );
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.CreateErrorResponse<List<LivroResponse>>(
                    new List<string> { ex.Message },
                    StatusCode.InternalServerError
                    );
            }

        }
        public Task<ApiResponse> DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }


        public async Task<ApiResponse<LivroResponse>> InsertBook(LivroRequestDto livro)
        {
            try
            {
                if (livro == null)
                {
                    return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
                           new List<string> { "Missing data."},
                           StatusCode.BadRequest
                        );
                }

                if (string.IsNullOrWhiteSpace(livro.Titulo))
                {
                    return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
                        new List<string> { "Title is required." },
                        StatusCode.BadRequest
                    );
                }

                if (string.IsNullOrWhiteSpace(livro.Autor))
                {
                    return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
                        new List<string> { "Author is required." },
                        StatusCode.BadRequest
                    );
                }

                if (livro.Preco <= 0)
                {
                    return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
                        new List<string> { "Price must be greater than zero." },
                        StatusCode.BadRequest
                    );
                }

                if (livro.Quantidade < 0)
                {
                    return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
                        new List<string> { "Quantity may not be less than 0." },
                        StatusCode.BadRequest
                    );
                }


                LivroResponse response = await _repository.InsertAsync(livro);


                return ApiResponseHelper.CreateResponse<LivroResponse>(
                        new LivroResponse
                        {
                            Id = response.Id,
                        },
                        StatusCode.Created
                    );

            }
            catch (SqlException ex)
            {
                return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
                    new List<string> { $"Database error: {ex.Message}" },
                    StatusCode.InternalServerError
                    );
            }

            catch (Exception ex)
            {
                return ApiResponseHelper.CreateErrorResponse<LivroResponse>(
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

using Azure;
using Dapper;
using GerenciadorDeLivraria.Dtos;
using GerenciadorDeLivraria.Entities;
using Microsoft.Data.SqlClient;

namespace GerenciadorDeLivraria.Repositories
{
    public class LivrariaRepository : BaseRepository<LivroRequestDto, LivroResponse>
    {
        public LivrariaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        async public override Task<List<LivroResponse>> GetAsync()
        {
            string query = @"SELECT ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE FROM LIVROS";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);

                IEnumerable<LivroResponse> result = await connection.QueryAsync<LivroResponse>(query);

                return result.ToList();

            }
            catch (SqlException ex)
            {
                throw new Exception($"Error performing database query: {ex.Message}", ex);
            }
        }

        async public override Task<LivroResponse> DeleteAsync(Guid id)
        {
            string query = @"DELETE FROM LIVROS
                            WHERE ID = @ID 
                           ";
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);

                if (id == Guid.Empty)
                {
                    throw new Exception("No rows were affected, the insert may have failed.");
                }

                var operation = await connection.ExecuteAsync(query, new { @ID = id });

                if (operation == 0)
                {
                    throw new Exception("No rows were affected, the delete operation may have failed.");
                }

                return new LivroResponse
                {
                    Id = id,
                };
            }
            catch (SqlException ex)
            {
                throw new Exception($"Failed to delete book into the database: {ex.Message}", ex);
            }

        }

        async public override Task<LivroResponse> InsertAsync(LivroRequestDto livro)
        {
            string query = @"INSERT INTO LIVROS (ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE)
                            OUTPUT INSERTED.ID
                            VALUES(@ID, @TITULO, @AUTOR, @GENERO, @PRECO, @QUANTIDADE)";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);

                Guid id = await connection.QuerySingleAsync<Guid>(query, new
                {
                    @ID = Guid.NewGuid(),
                    @TITULO = livro.Titulo,
                    @AUTOR = livro.Autor,
                    @GENERO = livro.Genero,
                    @PRECO = livro.Preco,
                    @QUANTIDADE = livro.Quantidade
                });

                if (id == Guid.Empty)
                {
                    throw new InvalidOperationException("No rows were affected, the insert may have failed.");
                }

                return new LivroResponse { Id = id };

            }
            catch (SqlException ex)
            {
                throw new Exception($"Failed to insert new book into the database: {ex.Message}", ex);
            }
        }

        async public override Task<LivroResponse> UpdateAsync(Guid id, LivroRequestDto livro)
        {
            string query = @"SELECT ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE FROM LIVROS
                            WHERE ID = @ID
                            ";
            try
            {

                using SqlConnection connection = new SqlConnection(_connectionString);

                if (id == Guid.Empty)
                {
                    throw new InvalidOperationException("No rows were affected, the update may have failed.");
                }

                LivroResponse bookResponse = await connection.QueryFirstOrDefaultAsync<LivroResponse>(query, new { @ID = id });

                if (bookResponse == null)
                {
                    throw new InvalidOperationException("No books were found with this ID.");
                }

                query = @"UPDATE LIVROS
                            SET
                                TITULO = @TITULO,
                                AUTOR = @AUTOR,
                                GENERO = @GENERO,
                                PRECO = @PRECO,
                                QUANTIDADE = @QUANTIDADE
                            WHERE ID = @ID
                            ";

                var operation = await connection.ExecuteAsync(query, new
                {
                    bookResponse.Titulo,
                    bookResponse.Autor,
                    bookResponse.Genero,
                    bookResponse.Preco,
                    bookResponse.Quantidade,
                    Id = id
                });

                if (operation == 0)
                {
                    throw new Exception("No rows were affected, the update operation may have failed.");
                }

                return new LivroResponse
                {
                    Id = id,
                    Autor = livro.Autor,
                    Genero = livro.Genero,
                    Preco = livro.Preco,
                    Quantidade = livro.Quantidade,
                    Titulo = livro.Titulo
                };
            }
            catch (SqlException ex)
            {
                throw new Exception($"Failed to update book into the database: {ex.Message}", ex);
            }
        }
    }

}

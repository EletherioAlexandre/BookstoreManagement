using Dapper;
using GerenciadorDeLivraria.Dtos;
using GerenciadorDeLivraria.Enums;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Settings;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace GerenciadorDeLivraria.Repositories
{
    public class LivrariaRepository : BaseRepository<Livro>
    {
        public LivrariaRepository(IConfiguration configuration) : base(configuration)
        {
        }

        async public override Task<List<Livro>> GetAsync()
        {
            string query = @"SELECT ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE FROM LIVROS";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);

                IEnumerable<Livro> result = await connection.QueryAsync<Livro>(query);

                return result.ToList();

            }
            catch (SqlException ex)
            {
                throw new Exception($"Error performing database query: {ex.Message}", ex);
            }
        }

        public override Task DeleteAsync(int id)
        {
            //using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            //{
            //    return;
            //}
            throw new NotImplementedException();
        }

        async public override Task InsertAsync(Livro livro)
        {
            string query = @"INSERT INTO LIVROS (ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE)
                             VALUES(@ID, @TITULO, @AUTOR, @GENERO, @PRECO, @QUANTIDADE)";

            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);

                var operation = await connection.ExecuteAsync(query, new
                {
                    @ID = Guid.NewGuid(),
                    @TITULO = livro.Titulo,
                    @AUTOR = livro.Autor,
                    @GENERO = livro.Genero,
                    @PRECO = livro.Preco,
                    @QUANTIDADE = livro.Quantidade
                });

                if (operation == 0)
                {
                    throw new Exception("No rows were affected, the insert may have failed.");
                }

            }
            catch (SqlException ex) 
            {
                throw new Exception($"Failed to insert new book into the database: {ex.Message}", ex);
            }
        }

        public override Task UpdateAsync(Livro livro)
        {
            throw new NotImplementedException();
        }
    }

}

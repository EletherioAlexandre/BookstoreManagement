using Dapper;
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
            var query = @"SELECT ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE FROM LIVROS";

            try
            {
                using var connection = new SqlConnection(_connectionString);

                IEnumerable<Livro> result = await connection.QueryAsync<Livro>(query);

                return result.ToList();

            }
            catch (SqlException ex)
            {
                throw new Exception($"Error performing database query: {ex.Message}", ex);
            }
        }

        public override void DeleteAsync(int id)
        {
            //using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            //{
            //    return;
            //}
            throw new NotImplementedException();
        }

        public override void InsertAsync(Livro livro)
        {
            throw new NotImplementedException();
        }

        public override void UpdateAsync(Livro livro)
        {
            throw new NotImplementedException();
        }
    }

}

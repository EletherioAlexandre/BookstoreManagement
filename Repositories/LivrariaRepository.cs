using Dapper;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
using Microsoft.Data.SqlClient;

namespace GerenciadorDeLivraria.Repositories
{
    public class LivrariaRepository : IBaseRepository<Livro>
    {
        private readonly string _connectionString;

        public LivrariaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionSqlServer");
        }

        public List<Livro> Get()
        {
            var query = @"SELECT ID, TITULO, AUTOR, GENERO, PRECO, QUANTIDADE FROM LIVROS";

            try
            {
                using var connection = new SqlConnection(_connectionString);

                return connection.Query<Livro>(query).ToList();

            }
            catch (SqlException ex)
            {
                throw new Exception($"Error performing database query: {ex.Message}", ex);
            }
        }

        public void Delete(int id)
        {
            //using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            //{
            //    return;
            //}
            throw new NotImplementedException();
        }

        public void Insert(Livro livro)
        {
            throw new NotImplementedException();
        }

        public void Update(int id)
        {
            throw new NotImplementedException();
        }
    }

}

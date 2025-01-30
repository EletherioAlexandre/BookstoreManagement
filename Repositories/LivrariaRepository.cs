using Dapper;
using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Models;
using GerenciadorDeLivraria.Settings;
using Microsoft.Data.SqlClient;

namespace GerenciadorDeLivraria.Repositories
{
    public class LivrariaRepository : ILivrariaRepository
    {
        public void DeleteBook(int id)
        {
            //using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            //{
            //    return;
            //}
            throw new NotImplementedException();
        }

        public List<Livro> GetAllBooks()
        {
            var query = @"SELECT * FROM LIVROS";

            using (var connection = new SqlConnection(SqlServerSettings.GetConnectionString()))
            {
                connection.Open();
                
                return connection.Query<Livro>(query).ToList();
            }
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

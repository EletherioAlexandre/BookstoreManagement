using GerenciadorDeLivraria.Interfaces;
using GerenciadorDeLivraria.Settings;
using Microsoft.Extensions.Options;

namespace GerenciadorDeLivraria.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly string _connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionSqlServer");
        }
        public abstract void DeleteAsync(int id);

        public abstract Task<List<T>> GetAsync();

        public abstract void InsertAsync(T entity);

        public abstract void UpdateAsync(T entity);
    }
}

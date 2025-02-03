using GerenciadorDeLivraria.Interfaces;

namespace GerenciadorDeLivraria.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly string _connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionSqlServer");
        }
        public abstract Task DeleteAsync(Guid id);

        public abstract Task<List<T>> GetAsync();

        public abstract Task InsertAsync(T entity);

        public abstract Task UpdateAsync(T entity);
    }
}

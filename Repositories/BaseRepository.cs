using GerenciadorDeLivraria.Interfaces;

namespace GerenciadorDeLivraria.Repositories
{
    public abstract class BaseRepository<TRequest, TResponse> : IBaseRepository<TRequest, TResponse> 
        where TRequest : class
        where TResponse : class
    {
        protected readonly string _connectionString;
        public BaseRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionSqlServer");
        }

        public abstract Task<TResponse> DeleteAsync(Guid id);

        public abstract Task<List<TResponse>> GetAsync();

        public abstract Task<TResponse> InsertAsync(TRequest entity);

        public abstract Task<TResponse> UpdateAsync(TRequest entity);
    }
}

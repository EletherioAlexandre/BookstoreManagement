namespace GerenciadorDeLivraria.Interfaces
{
    public interface IBaseRepository<TRequest, TResponse> 
        where TRequest : class
        where TResponse : class
    {
        #region Métodos Abstratos
        Task<TResponse> InsertAsync(TRequest entity);
        Task<TResponse> UpdateAsync(TRequest entity);
        Task<TResponse> DeleteAsync(Guid id);
        Task<List<TResponse>> GetAsync();
        #endregion
    }
}

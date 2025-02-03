namespace GerenciadorDeLivraria.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        #region Métodos Abstratos
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<List<T>> GetAsync();
        #endregion
    }
}

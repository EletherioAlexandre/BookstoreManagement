namespace GerenciadorDeLivraria.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        #region Métodos Abstratos
        void InsertAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(int id);
        Task<List<T>> GetAsync();
        #endregion
    }
}

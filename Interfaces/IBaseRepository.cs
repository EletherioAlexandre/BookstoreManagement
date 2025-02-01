using GerenciadorDeLivraria.Entities;
using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        #region Métodos Abstratos
        void Insert(T value);
        void Update(int id);
        void Delete(int id);
        List<T> Get();
        #endregion
    }
}

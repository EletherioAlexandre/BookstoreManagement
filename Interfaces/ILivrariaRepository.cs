using GerenciadorDeLivraria.Models;

namespace GerenciadorDeLivraria.Interfaces
{
    public interface ILivrariaRepository
    {
        #region Métodos Abstratos
        void InsertBook(Livro livro);
        void UpdateBook(int id);
        void DeleteBook(int id);
        List<Livro> GetAllBooks();
        #endregion
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using MyBooks.Model;

namespace MyBooks.DataService
{
    public interface IDataService
    {
        Task AddAsync(Book book);
        Task DeleteAsync(int id);
        //Task<ICollection<Book>> GetAllBooks(string tag);
        Task<ICollection<Book>> GetAllBooks();

    }
}
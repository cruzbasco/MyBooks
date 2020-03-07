using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyBooks.Model;

namespace MyBooks.DataService
{
    public class EFDataService : IDataService
    {
        private readonly BooksAppContext _db;

        public EFDataService()
        {
            _db = new BooksAppContext();
        }

        //public async Task<ICollection<Book>> GetAllBooks(string? tag)
        public async Task<ICollection<Book>> GetAllBooks()
        {
            var books = await _db.Books.ToListAsync();

            //if (!(tag is null))
            //{
            //    books = (from b in _db.Books
            //             join bt in _db.BookTags on b.Id equals bt.BookId
            //             join t in _db.Tags on bt.TagId equals t.Id
            //             where t.Name == tag
            //             select b
            //        ).ToList();
            //}
            return books;
        }

        public async Task AddAsync(Book book)
        {
            await _db.AddAsync(book);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bookToDelete = await _db.Books.FirstOrDefaultAsync(b => b.Id == id);
            if(bookToDelete != null)
            {
                _db.Books.Attach(bookToDelete);
                _db.Books.Remove(bookToDelete);
                await _db.SaveChangesAsync();
            }
            
        }



    }

}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Model
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }

    }
}

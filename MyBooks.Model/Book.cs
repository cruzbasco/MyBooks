using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<BookAuthor> BookAuthors { get; set; }
        public ICollection<BookTag> BookTags { get; set; }

    }
}

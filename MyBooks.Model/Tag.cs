using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBooks.Model
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<BookTag> BookTags { get; set; }

    }
}

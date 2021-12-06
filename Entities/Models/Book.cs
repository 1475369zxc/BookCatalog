using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }

        public List<Author> Authors { get; set; }
        public Book()
        {
            Authors = new List<Author>();
        }
    }
}

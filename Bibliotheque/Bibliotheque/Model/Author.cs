using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Model
{
    public class Author
    {
        public int NumAuthor { get; set; }

        public string NameAuthor { get; set; }

        private List<Book> book;
        public List<Book> Book { get; set; }

        public Author()
        {
            book = new List<Book>();
        }
    }
}

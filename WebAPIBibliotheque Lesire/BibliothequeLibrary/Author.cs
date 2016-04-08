using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeLibrary
{
    public class Author
    {
        private int numAuthor;
        public int NumAuthor { get; set; }

        private string nameAuthor;
        public string NameAuthor { get; set; }

        private List<Book> book;
        public List<Book> Book { get; set; }

        public Author()
        {
            book = new List<Book>();
        }
    }
}

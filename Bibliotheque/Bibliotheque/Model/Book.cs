using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.Model
{
    public class Book
    {
        public string NumBook { get; set; }

        public string Title { get; set; }

        public Nullable<int> YearPublication { get; set; }

        public Nullable<System.DateTime> DateEntry { get; set; }

        public string Editor { get; set; }

        public string Rangement { get; set; }

        public string Statut { get; set; }

        public Categorie Categorie { get; set; }

        public List<Author> Author { get; set; }

        public int NumberReservation { get; set; }

        private string listAuthorString;

        public Book()
        { }

        public string ListAuthor
        {
            get
            {
                listAuthorString = Author[0].NameAuthor;

                if (Author.Count > 1)
                {
                    for( var i = 1; i < Author.Count; i++)
                    {
                        listAuthorString += ", " + Author[i].NameAuthor;
                    }
                }
                return listAuthorString;
            }                
        }
    }
}

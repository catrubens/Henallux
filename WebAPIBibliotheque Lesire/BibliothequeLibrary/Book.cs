using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliothequeLibrary
{
    public class Book
    {
        private string numBook;
        public string NumBook { get; set; }

        private string title;
        public string Title { get; set; }

        private Nullable<int> yearPublication;
        public Nullable<int> YearPublication { get; set; }

        private Nullable<System.DateTime> dateEntry;
        public Nullable<System.DateTime> DateEntry { get; set; }

        private string editor;
        public string Editor { get; set; }

        private string rangement;
        public string Rangement { get; set; }

        private string statut;
        public string Statut { get; set; }

        private Categorie categorie;
        public Categorie Categorie { get; set; }

        private List<Author> author;
        public List<Author> Author { get; set; }

        private int numberReservation;
        public int NumberReservation { get; set; }

        public Book()
        {
            categorie = new Categorie();
            author = new List<Author>();
        }

    }
}

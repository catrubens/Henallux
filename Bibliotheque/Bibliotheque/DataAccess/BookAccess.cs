using Bibliotheque.Exceptions;
using Bibliotheque.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque.DataAccess
{
    public class BookAccess : InterfaceBook
    {
        private HttpClient client;
        private String allBook30LastDay = "http://bibliotheque.azurewebsites.net/api/books/getBooks30Days";
        private String searchBook = "http://bibliotheque.azurewebsites.net/api/books/searchBook/?wordSearch=";

        public BookAccess()
        {
            client = new HttpClient();
        }

        public async Task<ObservableCollection<Book>> GetBookSearch(string word, string categorie)
        {
            client.BaseAddress = new Uri(searchBook + word + "&categorie=" + categorie);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var booksResponse = JsonConvert.DeserializeObject<Book[]>(json);
                return fillBook(booksResponse);
            }
            else
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                string str = loader.GetString("noNetwork");
                throw new NoNetworkException(str);
            }
        }

        public async Task<ObservableCollection<Book>> GetBook30LastDays()
        {
            client.BaseAddress = new Uri(allBook30LastDay);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                var booksResponse = JsonConvert.DeserializeObject<Book[]>(json);
                return fillBook(booksResponse);
            }
            else
            {
                var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                string str = loader.GetString("noNetwork");
                throw new NoNetworkException(str);
            }
        }

        public ObservableCollection<Book> fillBook(Book[] booksResponse)
        {
            ObservableCollection<Book> listBooks = new ObservableCollection<Book>();
            foreach (var b in booksResponse)
            {
                Book book = new Book();
                book.Author = b.Author;
                book.Categorie = b.Categorie;
                book.DateEntry = b.DateEntry;
                book.Editor = b.Editor;
                book.NumberReservation = b.NumberReservation;
                book.NumBook = b.NumBook;
                book.Rangement = b.Rangement;
                book.Statut = b.Statut;
                book.Title = b.Title;
                book.YearPublication = b.YearPublication;
                listBooks.Add(book);
            }
            return listBooks;
        }
    }
}

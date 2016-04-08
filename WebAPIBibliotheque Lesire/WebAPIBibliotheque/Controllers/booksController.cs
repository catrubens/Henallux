using BibliothequeLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebAPIBibliotheque.Models;

namespace WebAPIBibliotheque.Controllers
{
    public class booksController : ApiController
    {
        private bibliothequeEntities1 db = new bibliothequeEntities1();

        [HttpGet, ActionName("getBooks30Days")]
        public IEnumerable<Book> getBooks30LastDays()
        {
            var dateOf30Days = DateTime.Now.Date.AddDays(-30);
            var queryResult = (from b in db.books
                               where b.DateEntry > dateOf30Days
                               select b).ToList();

            List<Book> listBook = new List<Book>();

            foreach (var b in queryResult)
            {
                Book book = new Book();
                fillBook(book, b);
                listBook.Add(book);
            }

            return listBook;
        }

        [HttpGet, ActionName("searchBook")]
        public IEnumerable<Book> searchBookByTitleOrEditorInDataBase(string wordSearch, string categorie)
        {
            categorie = categorie.Replace('_', ' ');
            List<Book> listBook = new List<Book>();
            List<Book> listBookNoDupli = new List<Book>();
            
            var queryResultTitle = (from b in db.books
                                    where b.CodeCategorie == categorie &&
                                    b.Title.Contains(wordSearch)
                                    select b).ToList();

            var queryResultEditor = (from b in db.books
                                     where b.CodeCategorie == categorie &&
                                     b.Editor.Contains(wordSearch)
                                     select b).ToList();

            var queryResultAuthor = (from a in db.authors
                                     where a.NameAuthor.Contains(wordSearch)
                                     select a.books.ToList()).ToList();
          
            foreach (var bT in queryResultTitle)
            {
                Book book = new Book();
                fillBook(book, bT);
                listBook.Add(book);
            }

            foreach (var bE in queryResultEditor)
            {
                Book book = new Book();
                fillBook(book, bE);
                listBook.Add(book);
            }

            foreach (var bA in queryResultAuthor)
            {
                foreach (var b in bA.Where(bc => bc.CodeCategorie == categorie))
                {
                    Book book = new Book();
                    fillBook(book, b);
                    listBook.Add(book);
                }
            }

            listBookNoDupli = listBook.Distinct().ToList();

            return listBookNoDupli;
        }

        private void fillBook(Book book, book b)
        {
            book.NumBook = b.NumBook;
            book.Title = b.Title;
            book.Editor = b.Editor;
            book.YearPublication = b.YearPublication;
            book.DateEntry = b.DateEntry;
            book.Rangement = b.Rangement;
            book.Statut = b.Statut;

            var queryResultCategorie = (from c in db.categories
                                        where c.CodeCategorie == b.CodeCategorie
                                        select c).First();

            Categorie categorie = new Categorie();
            categorie.CodeCategorie = queryResultCategorie.CodeCategorie;
            categorie.LibelleCategorie = queryResultCategorie.LibelleCategorie;

            book.Categorie = categorie;

            List<Author> listAuthor = new List<Author>();
            foreach (var a in b.authors)
            {
                Author author = new Author();
                author.NumAuthor = a.NumAuthor;
                author.NameAuthor = a.NameAuthor;
                listAuthor.Add(author);
            }
            book.Author = listAuthor;

            book.NumberReservation = b.reservations.Count();
        }

        /*
        // GET: api/books
        public List<string> Getbooks()
        {
            var dateOf30Days = DateTime.Now.Date.AddMonths(-2);
            var queryResult = (from b in db.books
                               where b.DateEntry > dateOf30Days
                               select b).ToList();

            List<string> list = new List<string>();

            foreach (var b in queryResult)
            {
                string book;
                book = b.NumBook;
                list.Add(book);
            }
            return list ;
        }
        
        // GET: api/books/5
        [ResponseType(typeof(book))]
        public IHttpActionResult Getbook(string id)
        {
            book book = db.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbook(string id, book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.NumBook)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!bookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/books
        [ResponseType(typeof(book))]
        public IHttpActionResult Postbook(book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.books.Add(book);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (bookExists(book.NumBook))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = book.NumBook }, book);
        }

        // DELETE: api/books/5
        [ResponseType(typeof(book))]
        public IHttpActionResult Deletebook(string id)
        {
            book book = db.books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.books.Remove(book);
            db.SaveChanges();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool bookExists(string id)
        {
            return db.books.Count(e => e.NumBook == id) > 0;
        }
        */
    }
}
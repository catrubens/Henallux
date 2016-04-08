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
    public class authorsController : ApiController
    {
        private bibliothequeEntities1 db = new bibliothequeEntities1();

        // GET: api/authors
        public IEnumerable<Author> Getauthors()
        {
            var queryResult = db.authors.ToList();

            List<Author> listAuthor = new List<Author>();

            foreach (var a in queryResult)
            {
                Author author = new Author();
                author.NameAuthor = a.NameAuthor;
                author.NumAuthor = a.NumAuthor;
                List<Book> listBook = new List<Book>();

                foreach (var b in a.books)
                {
                    Book book = new Book();
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
                    book.NumberReservation = b.reservations.Count();
                    listBook.Add(book);
                }
                author.Book = listBook;

                listAuthor.Add(author);
            }

            return listAuthor;
        }

        /*
        // GET: api/authors/5
        [ResponseType(typeof(author))]
        public IHttpActionResult Getauthor(int id)
        {
            author author = db.authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            return Ok(author);
        }

        // PUT: api/authors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putauthor(int id, author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != author.NumAuthor)
            {
                return BadRequest();
            }

            db.Entry(author).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!authorExists(id))
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

        // POST: api/authors
        [ResponseType(typeof(author))]
        public IHttpActionResult Postauthor(author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.authors.Add(author);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (authorExists(author.NumAuthor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = author.NumAuthor }, author);
        }

        // DELETE: api/authors/5
        [ResponseType(typeof(author))]
        public IHttpActionResult Deleteauthor(int id)
        {
            author author = db.authors.Find(id);
            if (author == null)
            {
                return NotFound();
            }

            db.authors.Remove(author);
            db.SaveChanges();

            return Ok(author);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool authorExists(int id)
        {
            return db.authors.Count(e => e.NumAuthor == id) > 0;
        }*/
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Books_Managment.Models;

namespace Books_Managment.Controllers
{
    public class BookController : Controller
    {

        private static List<Book> books;

        // GET: Book
        public ActionResult Index()
        {
            if (books == null)
            {
                books = new List<Book>();
                books.Add(new Book { Id = 1,Author="kinan",Title="Learn MVC",Price=112.3m });
                books.Add(new Book { Id = 2, Author = "Ahmad", Title = "ABC", Price = 100.6m });
                books.Add(new Book { Id = 3, Author = "Hasan", Title = "DD", Price = 90.36m });
                books.Add(new Book { Id = 4, Author = "Rayan", Title = "PP", Price = 886.3m });

            }
            return View(books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = books.Single(s => s.Id == id);
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                books.Add(book);
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = books.Single(s => s.Id == id);
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                // TODO: Add update logic here
                Book SelectedBook = books.Single(s => s.Id == id);
                SelectedBook.Author = book.Author;
                SelectedBook.Title = book.Title;
                SelectedBook.Price = book.Price;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book SelectedBook = books.Single(s => s.Id == id);
            return View(SelectedBook);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Book SelectedBook = books.Single(s => s.Id == id);
                books.Remove(SelectedBook);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

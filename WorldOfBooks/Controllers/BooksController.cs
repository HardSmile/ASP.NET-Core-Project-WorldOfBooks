namespace WorldOfBooks.Controllers
{
using Microsoft.AspNetCore.Mvc;
    using WorldOfBooks.Models.Books;

    public class BooksController : Controller
    {
        public IActionResult Add() => View();
        [HttpPost]
        public IActionResult Add(AddBookFormModel book)
        {
            return View();
        }
    }
}

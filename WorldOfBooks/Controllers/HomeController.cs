
namespace WorldOfBooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;
    using System.Linq;
    using WorldOfBooks.Data;
    using WorldOfBooks.Models;
    using WorldOfBooks.Models.Home;

    public class HomeController : Controller
    {
        private readonly WorldOfBooksDbContext data;
        public HomeController(WorldOfBooksDbContext data)
            => this.data = data;
        public IActionResult Index()
        {
            var totalBooks = this.data.Books.Count();
            var books = this.data
                .Books
                .OrderByDescending(b => b.Id)
                .Select(b => new BookIndexViewModel
                {
                    Id = b.Id,
                    Book = b.NameOfBook,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                }).Take(3)
                .ToList();
            return View(new IndexViewModel
            {
                TotalBooks = totalBooks,
                Books = books
            }); 
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

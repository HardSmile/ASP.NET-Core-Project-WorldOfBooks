namespace WorldOfBooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WorldOfBooks.Models.Books;
    using System.Collections.Generic;
    using WorldOfBooks.Data;
    using System.Linq;
    using WorldOfBooks.Data.Models;

    public class BooksController : Controller
    {
        private readonly WorldOfBooksDbContext data;
        public BooksController(WorldOfBooksDbContext data) 
            => this.data = data;
        public IActionResult Add() => View(new AddBookFormModel
        {
            Categories = this.GetBookCategories()
        });
        [HttpPost]
        public IActionResult Add(AddBookFormModel nameOfBook)
        {
            if (this.data.Categories.Any(c => c.Id == nameOfBook.CategoryId))
            {
                this.ModelState.AddModelError(nameof(nameOfBook.CategoryId), "Category does exist.");
            }
            if (!ModelState.IsValid)
            {
                nameOfBook.Categories = this.GetBookCategories();
                return View(nameOfBook);
            }
            var bookData = new Book
            {
                Author = nameOfBook.Author,
                Description = nameOfBook.Description,
                ImageUrl = nameOfBook.ImageUrl,
                CategoryId = nameOfBook.CategoryId,
                Year = nameOfBook.Year,

            };
            this.data.Books.Add(bookData);
            this.data.SaveChanges();

            return RedirectToAction("Index","Home");
        }
        private IEnumerable<BookCategoryViewModel> GetBookCategories()
        =>
            this.data
                .Categories
                .Select(c =>new BookCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }) .ToList();
            }
               
        }


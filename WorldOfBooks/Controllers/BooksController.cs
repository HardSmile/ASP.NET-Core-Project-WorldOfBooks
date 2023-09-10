namespace WorldOfBooks.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using WorldOfBooks.Models.Books;
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
        public IActionResult All(string author, string searchTerm)
        {
            var booksQuery = this.data.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(author))
            {
                booksQuery = booksQuery.Where(b => b.Author == author);
            }
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                booksQuery = booksQuery.Where(
                    b => b.NameOfBook.ToLower().Contains(searchTerm.ToLower())
                    || b.Author.ToLower().Contains(searchTerm.ToLower())
                    || b.Description.ToLower().Contains(searchTerm.ToLower())
                    );
            }
            var books = booksQuery
                .OrderByDescending(b=>b.Id)
                .Select(b => new BookListingViewModel
                {
                    Id = b.Id,
                    Book = b.NameOfBook,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Category = b.Category.Name
                }).ToList();
            var bookAuthors = this.data
                .Books
                .Select(b => b.Author)
                .Distinct()
                .ToList();
            return View(new AllBooksViewModel
            { 
            Authors = bookAuthors,
            Books = books,
            SearchTerm = searchTerm
            });
        }
        [HttpPost]
        public IActionResult Add(AddBookFormModel book)
        {
            if (!this.data.Categories.Any(c => c.Id == book.CategoryId))
            {
                this.ModelState.AddModelError(nameof(book.CategoryId), "Category does exist.");
            }
            if (!ModelState.IsValid)
            {
                book.Categories = this.GetBookCategories();
                return View(book);
            }
            var bookData = new Book
            {
                NameOfBook = book.NameOfBook,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                CategoryId = book.CategoryId
            };
            this.data.Books.Add(bookData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
        }
        private IEnumerable<BookCategoryViewModel> GetBookCategories()
        => this.data
                .Categories
                .Select(c =>new BookCategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }) .ToList();
            }
               
        }


namespace WorldOfBooks.Models.Books
{
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllBooksViewModel
    {
        public const int BooksPerPage = 3;
        public string Author { get; set; }
        public IEnumerable<string> Authors { get; set; }
        [Display (Name = "Search")]
        public string SearchTerm { get; set; }
        public BookSorting Sorting { get; set; }
        public int CurrentPage { get; set; } = 1;
        public int TotalBooks { get; set;}
        public IEnumerable<BookListingViewModel> Books { get; set; }
       
    }
}

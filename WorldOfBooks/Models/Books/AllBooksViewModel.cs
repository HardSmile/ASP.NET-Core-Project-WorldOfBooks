namespace WorldOfBooks.Models.Books
{
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllBooksViewModel
    {
        public string Author { get; init; }
        public IEnumerable<string> Authors { get; init; }
        [Display (Name = "Search")]
        public string SearchTerm { get; init; }
        public BookSorting Sorting { get; init; }
        public IEnumerable<BookListingViewModel> Books { get; init; }
       
    }
}

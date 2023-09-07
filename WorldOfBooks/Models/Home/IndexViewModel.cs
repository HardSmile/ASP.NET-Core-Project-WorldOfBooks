using System.Collections;
using System.Collections.Generic;

namespace WorldOfBooks.Models.Home
{
    public class IndexViewModel
    {
        public int TotalBooks { get; init; }
        public int TotalUsers { get; init; }
        public List<BookIndexViewModel> Books { get; init; }
    }
}

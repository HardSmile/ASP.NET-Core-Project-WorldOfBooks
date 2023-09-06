using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WorldOfBooks.Models.Books
{
    public class AddBookFormModel
    {
        public string NameOfBook { get; set; }
       
        public string Author { get; set; }
   
        public string Description { get; set; }
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; }

        public int Year { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public IEnumerable<BookCategoryViewModel> Categories { get; set; }
    }
}

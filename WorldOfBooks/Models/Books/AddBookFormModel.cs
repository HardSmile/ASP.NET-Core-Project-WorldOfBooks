
namespace WorldOfBooks.Models.Books
{
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;
    public class AddBookFormModel
    {
        [Display(Name = "Name Of Book")]
        [Required]
        [MaxLength(BookMaxLength)]
        [MinLength(BookMinLegth)]
        public string NameOfBook { get; init; }
        [Required]
        [MaxLength(AuthorMakeMaxLength)]
        [MinLength(AuthorMakeMinLength)]
        public string Author { get; init; }
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionBookMinLegth)]

        public string Description { get; init; }
        [Display(Name = "Image URL")]
        [Required]
        public string ImageUrl { get; init; }

        [Display(Name = "Category")]
        public int CategoryId { get; init; }
        public IEnumerable<BookCategoryViewModel> Categories { get; set; }
    }
}

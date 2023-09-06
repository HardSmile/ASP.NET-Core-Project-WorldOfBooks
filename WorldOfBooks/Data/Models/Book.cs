namespace WorldOfBooks.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;
    public class Book
    {
        public int Id { get; set; }
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
        [Required]
        public string ImageUrl { get; init; }

        public int CategoryId { get; init; }
        public Category Category { get; set;  }

    }
}

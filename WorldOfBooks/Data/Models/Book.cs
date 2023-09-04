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
        public string BookName { get; set; }
        [Required]
        [MaxLength(AuthorMakeMaxLength)]
        [MinLength(AuthorMakeMinLength)]
        public string Author { get; set; }
        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionBookMinLegth)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public int Year { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

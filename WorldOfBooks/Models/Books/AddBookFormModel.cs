namespace WorldOfBooks.Models.Books
{
    public class AddBookFormModel
    {
        public string Book { get; set; }
       
        public string Author { get; set; }
   
        public string Description { get; set; }
     
        public string ImageUrl { get; set; }

        public int Year { get; set; }
        public int CategoryId { get; set; }
    }
}

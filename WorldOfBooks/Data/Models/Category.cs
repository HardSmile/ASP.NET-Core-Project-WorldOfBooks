namespace WorldOfBooks.Data.Models
{
    using System.Collections.Generic;
    using System.Linq;
    public class Category
    {
        public int id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Book> Books { get; set;} = new List<Book>();
    }
}

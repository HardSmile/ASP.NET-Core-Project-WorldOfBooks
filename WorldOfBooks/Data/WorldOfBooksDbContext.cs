namespace WorldOfBooks.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using WorldOfBooks.Data.Models;

    public class WorldOfBooksDbContext : IdentityDbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public WorldOfBooksDbContext(DbContextOptions<WorldOfBooksDbContext> options)
            : base(options)
        {
        }
    }
}

namespace WorldOfBooks.Infrastructure
{
using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using WorldOfBooks.Data;
    using WorldOfBooks.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
           using var scopedServices = app.ApplicationServices.CreateScope();
           var data = scopedServices.ServiceProvider.GetService<WorldOfBooksDbContext>();
            data.Database.Migrate();
            SeedCategories(data);
            return app;
        }
        private static void SeedCategories(WorldOfBooksDbContext data)
        {
            if (!data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                 new Category { Name ="Comedy"},
                 new Category { Name ="Triler"},
                 new Category { Name ="Action"},
                 new Category { Name ="Drama"},
                new Category { Name ="Psycho"}
            });
        }
        
    }
}

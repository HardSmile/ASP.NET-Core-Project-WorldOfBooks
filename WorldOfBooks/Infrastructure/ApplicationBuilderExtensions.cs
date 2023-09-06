namespace WorldOfBooks.Infrastructure
{
using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Linq;
    using WorldOfBooks.Data;
    using WorldOfBooks.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
           using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;
            MigrateDatabase(services);
            SeedCategories(services);
            return app;
        }
        private static void MigrateDatabase(IServiceProvider services)
        {
            var data = services.GetRequiredService<WorldOfBooksDbContext>();

            data.Database.Migrate();
        }
        private static void SeedCategories(IServiceProvider services)
        {
            var data = services.GetRequiredService<WorldOfBooksDbContext>();
            if (data.Categories.Any())
            {
                return;
            }
            data.Categories.AddRange(new[]
            {
                new Category { Name = "Literary Fiction"},
                new Category { Name = "Mystery"},
                new Category { Name = "Thriller"},
                new Category { Name = "Horror"},
                new Category { Name = "Historical"},
                new Category { Name = "Romance"},
                new Category { Name = "Western"},
                new Category { Name = "Bildungsroman"},
                new Category { Name = "Speculative Fiction"},
                new Category { Name = "Science Fiction"},
                new Category { Name = "Fantasy"},
                new Category { Name = "Dystopian"},
                new Category { Name = "Magical Realism"},
                new Category { Name = "Realist Literature."},
            });
            data.SaveChanges();
        }
    }
       

    }


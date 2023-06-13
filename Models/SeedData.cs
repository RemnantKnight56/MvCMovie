using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Models;
using MvCMovie.Data;
using System;
using System.Linq;

namespace MvCMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvCMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvCMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Meet the Mormons",
                    ReleaseDate = DateTime.Parse("2014-10-10"),
                    Genre = "Documentary",
                    Price = 7.99M, 
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "The R.M.",
                    ReleaseDate = DateTime.Parse("2003-1-31"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "The Other Side of Heaven",
                    ReleaseDate = DateTime.Parse("2001-12-14"),
                    Genre = "Drama",
                    Price = 9.99M,
                    Rating = "PG"
                }
            );
            context.SaveChanges();
        }
    }
}

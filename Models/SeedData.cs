using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvCMovie.Models;
using MvCMovie.Data;
using System;
using System.Linq;

namespace MvCMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new MvCMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvCMovieContext>>());
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
                Rating = "PG",
                Image = "https://lds365.com/wp-content/uploads/2015/03/Meet-the-Mormons-DVD-600x828.jpg"
            },
            new Movie
            {
                Title = "The R.M.",
                ReleaseDate = DateTime.Parse("2003-1-31"),
                Genre = "Comedy",
                Price = 8.99M,
                Rating = "PG",
                Image = "https://alchetron.com/cdn/The-RM-images-054adc72-ecf6-48f4-badb-0033111ea13.jpg"
            },
            new Movie
            {
                Title = "The Other Side of Heaven",
                ReleaseDate = DateTime.Parse("2001-12-14"),
                Genre = "Drama",
                Price = 9.99M,
                Rating = "PG",
                Image = "https://image.tmdb.org/t/p/original/9MfYiummofdtMTOgweXf9yyPl4L.jpg"
            }
        );
        context.SaveChanges();
    }
}

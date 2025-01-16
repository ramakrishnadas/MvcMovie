using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "R"
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Genre = "Comedy",
                    Price = 8.99M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Genre = "Comedy",
                    Price = 9.99M,
                    Rating = "R"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Genre = "Western",
                    Price = 3.99M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "Harry Potter and the Sorcerer's Stone",
                    ReleaseDate = DateTime.Parse("2001-11-23"),
                    Genre = "Fantasy",
                    Price = 2.99M,
                    Rating = "PG"
                },
                new Movie
                {
                    Title = "The Lord of the Rings: The Fellowship of the Ring",
                    ReleaseDate = DateTime.Parse("2001-12-19"),
                    Genre = "Adventure",
                    Price = 1.50M,
                    Rating = "PG-13"
                },
                new Movie
                {
                    Title = "Fight Club",
                    ReleaseDate = DateTime.Parse("1999-10-15"),
                    Genre = "Drama",
                    Price = 2.00M,
                    Rating = "R"
                }
            );
            context.SaveChanges();
        }
    }
}
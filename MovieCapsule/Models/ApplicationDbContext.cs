using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCapsule.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Fluent Attribute instead of Data Attribute as [Required] in entity classes
            modelBuilder
                .Entity<Genre>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20);
            //Create Genres
            var adv = new Genre() { Id = 1, Name = "Adventure" };
            var act = new Genre() { Id = 2, Name = "Action" };
            var ani = new Genre() { Id = 3, Name = "Animation" };
            var bio = new Genre() { Id = 4, Name = "Biography" };
            var com = new Genre() { Id = 5, Name = "Comedy" };
            var cri = new Genre() { Id = 6, Name = "Crime" };
            var doc = new Genre() { Id = 7, Name = "Documentary" };
            var dra = new Genre() { Id = 8, Name = "Drama" };
            var fam = new Genre() { Id = 9, Name = "Family" };
            var fan = new Genre() { Id = 10, Name = "Fantasy" };
            var his = new Genre() { Id = 11, Name = "History" };
            var hor = new Genre() { Id = 12, Name = "Horror" };
            var mus = new Genre() { Id = 13, Name = "Musical" };
            var mys = new Genre() { Id = 14, Name = "Mystery" };
            var rom = new Genre() { Id = 15, Name = "Romance" };
            var sci = new Genre() { Id = 16, Name = "Sci-Fi" };
            var spo = new Genre() { Id = 17, Name = "Sport" };
            var thr = new Genre() { Id = 18, Name = "Thriller" };
            var war = new Genre() { Id = 19, Name = "War" };
            var wes = new Genre() { Id = 20, Name = "Western" };

            modelBuilder.Entity<Genre>().HasData(adv, act, ani, bio, com, cri, doc, dra, fam, fan, his, hor, mus, mys, rom, sci, spo, thr, war, wes);
            //Fluent Attribute instead of Data Attribute as [Required] in entity classes
            modelBuilder
                .Entity<Movie>()
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);
            //Fluent Attribute instead of Data Attribute as [Required] in entity classes
            modelBuilder
                .Entity<Movie>()
                .Property(x => x.Rating)
                .HasColumnType("decimal(3,1)");
            //Create Movies 
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { Id = 1, Title = "John Wick", Rating = 7.4m, Year = 2014 },
                new Movie() { Id = 2, Title = "The Lord of the Rings: The Fellowship of the Ring", Rating = 8.8m, Year = 2001 },
                new Movie() { Id = 3, Title = "Interstellar", Rating = 8.6m, Year = 2014 },
                new Movie() { Id = 4, Title = "Free Guy", Rating = 7.2m, Year = 2021 },
                new Movie() { Id = 5, Title = "Oldboy", Rating = 8.4m, Year = 2003 },
                new Movie() { Id = 6, Title = "Parasite", Rating = 8.6m, Year = 2019 },
                new Movie() { Id = 7, Title = "Like Stars On Earth", Rating = 8.4m, Year = 2007 },
                new Movie() { Id = 8, Title = "Arrival", Rating = 7.9m, Year = 2016 },
                new Movie() { Id = 9, Title = "Life Is Beautiful", Rating = 8.6m, Year = 1997 },
                new Movie() { Id = 10, Title = "Persona", Rating = 8.1m, Year = 1966 },
                new Movie() { Id = 11, Title = "Cars", Rating = 7.1m, Year = 2006 },
                new Movie() { Id = 12, Title = "Gone Girl", Rating = 8.1m, Year = 2014 }
                );

            //Create Connection between movie and genres
            // https://docs.microsoft.com/en-us/ef/core/modeling/relationships?tabs=fluent-api%2Cfluent-api-simple-key%2Csimple-key#joining-relationships-configuration
            modelBuilder
                .Entity<Genre>()
                .HasMany(x => x.Movies)
                .WithMany(x => x.Genres)
                .UsingEntity<Dictionary<string, object>>( 
                    "MovieGenre",
                    x => x.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    x => x.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                    x => x.HasData(
                        new { MovieId = 1, GenreId = 2 },
                        new { MovieId = 1, GenreId = 6 },
                        new { MovieId = 1, GenreId = 18 },
                        new { MovieId = 2, GenreId = 1 },
                        new { MovieId = 2, GenreId = 2 },
                        new { MovieId = 2, GenreId = 8 },
                        new { MovieId = 3, GenreId = 1 },
                        new { MovieId = 3, GenreId = 8 },
                        new { MovieId = 3, GenreId = 16 },
                        new { MovieId = 4, GenreId = 1 },
                        new { MovieId = 4, GenreId = 2 },
                        new { MovieId = 4, GenreId = 5 },
                        new { MovieId = 5, GenreId = 2 },
                        new { MovieId = 5, GenreId = 8 },
                        new { MovieId = 5, GenreId = 14 },
                        new { MovieId = 6, GenreId = 5 },
                        new { MovieId = 6, GenreId = 8 },
                        new { MovieId = 6, GenreId = 18 },
                        new { MovieId = 7, GenreId = 8 },
                        new { MovieId = 7, GenreId = 9 },
                        new { MovieId = 8, GenreId = 8 },
                        new { MovieId = 8, GenreId = 16 },
                        new { MovieId = 9, GenreId = 5 },
                        new { MovieId = 9, GenreId = 8 },
                        new { MovieId = 9, GenreId = 15 },
                        new { MovieId = 10, GenreId = 8 },
                        new { MovieId = 10, GenreId = 18 },
                        new { MovieId = 11, GenreId = 1 },
                        new { MovieId = 11, GenreId = 3 },
                        new { MovieId = 11, GenreId = 5 },
                        new { MovieId = 12, GenreId = 8 },
                        new { MovieId = 12, GenreId = 14 },
                        new { MovieId = 12, GenreId = 18 }
                        )
                );
        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}

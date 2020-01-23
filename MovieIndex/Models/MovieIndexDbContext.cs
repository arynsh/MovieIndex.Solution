using Microsoft.EntityFrameworkCore;

namespace MovieIndex.Models
{
    public class MovieIndexDbContext : DbContext
    {
        public virtual DbSet<Genre> Genres {get; set;}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<GenreMovie> GenreMovie { get; set; }
        public MovieIndexDbContext(DbContextOptions options) : base(options) {}
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieIndex.Models
{
    public class MovieIndexContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Genre> Genres {get; set;}
        public DbSet<Movie> Movies {get; set;}
        public DbSet<GenreMovie> GenreMovie { get; set; }
        public MovieIndexContext(DbContextOptions options) : base(options) {}
    }
}
using System;
using System.Collections.Generic;

namespace MovieIndex.Models
{
    public class Movie
    {
        public Movie()
        {
            this.Genres = new HashSet<GenreMovie>();
        }
        
        public string Name { get; set; }
        public int MovieId { get; set; }
        public int Year { get; set; }
        public virtual ApplicationUser User { get; set; }
        public ICollection<GenreMovie> Genres { get; }
    }
}
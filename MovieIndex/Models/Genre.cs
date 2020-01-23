using System;
using System.Collections.Generic;

namespace MovieIndex.Models
{
    public class Genre 
    {
        public Genre()
        {
            this.Movies = new HashSet<GenreMovie>();
        }

        public string Name { get; set; }
        public int GenreId { get; set; }
        public virtual ICollection<GenreMovie> Movies { get; set; }
    }
}
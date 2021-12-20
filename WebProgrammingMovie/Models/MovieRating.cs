using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgrammingMovie.Models
{
    public class MovieRating
    {
        public MovieRating(Movie movie,Rating rating)
        {
            _Movie = movie;
            _Rating = rating;
            
        }
        public Movie _Movie { get; set; }
        public Rating _Rating { get; set; }
    }
}

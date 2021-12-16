using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebProgrammingMovie.Enum;

namespace WebProgrammingMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Film Adı")]
        public string Name { get; set; }

        public string Review { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public ICollection<Photo> Photo { get; set; }

        public ICollection<Actor> Actor { get; set; }

        public ICollection<Director> Director{ get; set; }

        public ICollection<Rating> Rating { get; set; }


        public DateTime ReleaseDate { get; set; }

        public int Duration { get; set; }

        public double IMDB { get; set; }

        public CountryEnum Country { get; set; }

    }
    

}

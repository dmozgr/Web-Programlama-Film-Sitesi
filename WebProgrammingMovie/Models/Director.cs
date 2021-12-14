using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgrammingMovie.Models
{
    public class Director
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string SurName { get; set; }

        public ICollection<Movie> Movie { get; set; }

        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return Name + " " + SurName;
            }
        }
    }
}

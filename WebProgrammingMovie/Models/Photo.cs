using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgrammingMovie.Models
{
    public class Photo
    {
        public int Id { get; set; }

        public string PhotoName { get; set; }

        public int? MovieId { get; set; }
        [ForeignKey("UrunId")]
        public Movie Movie { get; set; }
    }
}

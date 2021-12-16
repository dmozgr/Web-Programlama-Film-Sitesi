using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebProgrammingMovie.Enum;

namespace WebProgrammingMovie.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }
        public CountryEnum Country { get; set; }

        [NotMapped]
        public string AdSoyad
        {
            get
            {
                return Name + " " + Surname;
            }
        }


    }
}

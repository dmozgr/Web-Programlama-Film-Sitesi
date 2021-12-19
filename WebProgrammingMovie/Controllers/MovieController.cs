using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProgrammingMovie.Data;
using WebProgrammingMovie.Models;

namespace WebProgrammingMovie.Controllers
{
    public class MovieController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovieController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Movie/{id}")]
        public IActionResult Index(int? id)
        {
            if(id ==null)
            {
                return null;
                
            }
            else
            {
                Movie movie = _context.Movie.Include(x=>x.Category).Single(x => x.Id == id);

                if(movie ==null)
                {
                    return null;

                }
                else
                {
                    return View(movie);
                }
            }
        }

    }
}

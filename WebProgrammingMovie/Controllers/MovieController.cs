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

        // GET: Admin/Movie/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["DirectorId"] = new SelectList(_context.Director, "Id", "DirectorName");
            return View();
        }

        // POST: Admin/Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Review,View,CategoryId,DirectorId,SliderPhotoURL,DetailPhotoURL,ReleaseDate,Duration,IMDB,Country")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name", movie.CategoryId);
            ViewData["DirectorId"] = new SelectList(_context.Director, "Id", "DirectorName", movie.DirectorId);
            return View(movie);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _UserManager;

        public MovieController(ApplicationDbContext context,UserManager<IdentityUser> UserManager)
        {
            _UserManager = UserManager;
            _context = context;
        }

        [Route("Movie/{id}")]
        public IActionResult Index(int? id)
        {
            Movie movie = _context.Movie.Include(x=>x.Category).Include(x => x.Actor).Include(x => x.Rating).Single(x => x.Id == id);
            List<Rating> ratings = _context.Rating.Where(x => x.MovieId == movie.Id).ToList();
            List<RatingAndUser> ratinganduser = new List<RatingAndUser>();
            double totalRating = 0;
            int index = 0;

            foreach(var item in ratings)
            {
                Rating rating1 = item;
                ApplicationUser user1 = (ApplicationUser)_context.ApplicationUser.Single(x => x.Id == item.UserId);
                RatingAndUser firstitem = new RatingAndUser(rating1, user1);
                ratinganduser.Add(firstitem);
                totalRating += item.Score;
                index++;
            }
            totalRating = totalRating / index;

            MovieRating movieRating = new MovieRating(movie, ratinganduser,totalRating);

            return View(movieRating);        
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            ViewData["DirectorId"] = new SelectList(_context.Director, "Id", "DirectorName");
            return View();
        }

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

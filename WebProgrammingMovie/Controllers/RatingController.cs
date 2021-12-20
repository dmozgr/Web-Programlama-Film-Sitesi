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
    public class RatingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _UserManager;
        private int? movieId;

        public RatingController(ApplicationDbContext context, UserManager<IdentityUser> UserManager)
        {
            _UserManager = UserManager;
            _context = context;
        }

       

        // GET: Rating/Create

        public IActionResult Create(int? id)
        {
            movieId = id;
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id");
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Name");
            var model = new Rating() { MovieId=id};
            return View(model);
        }

        // POST: Rating/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Comment,CommentDate,MovieId,UserId,Score")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                rating.UserId = _UserManager.GetUserId(HttpContext.User);
                rating.CommentDate = DateTime.Now;
                
                _context.Add(rating);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Movie",new { id=rating.MovieId});
            }
            ViewData["UserId"] = new SelectList(_context.ApplicationUser, "Id", "Id", rating.UserId);
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Name", rating.MovieId);
            
            return View(rating);
        }

       
    }
}

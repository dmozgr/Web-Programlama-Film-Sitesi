using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebProgrammingMovie.Data;
using WebProgrammingMovie.Models;

namespace WebProgrammingMovie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var totalmovie = _context.Movie.Include(x => x.Category).ToList();
            var slidermovie = _context.Movie.Take(1).Include(x => x.Category).ToList();
            var trendmovie = _context.Movie.OrderByDescending(x => x.IMDB).Take(1).Include(x => x.Category).ToList();
            HomeViewModel homeview = new HomeViewModel(totalmovie, trendmovie, slidermovie);
            return View(homeview);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

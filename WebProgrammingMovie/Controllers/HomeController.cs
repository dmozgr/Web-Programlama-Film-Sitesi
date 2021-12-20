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
            var totalmovie = _context.Movie.Include(x => x.Category).Include(x=>x.Rating).Include(x => x.Actor).ToList();
            var slidermovie = _context.Movie.Take(2).Include(x => x.Category).Include(x => x.Rating).Include(x => x.Actor).ToList();
            var trendmovie = _context.Movie.OrderByDescending(x => x.IMDB).Take(2).Include(x => x.Category).Include(x => x.Actor).Include(x => x.Rating).ToList();

            HomeViewModel homeview = new HomeViewModel(totalmovie, trendmovie, slidermovie,"Yeni Çıkanlar");

            return View(homeview);
        }

        [Route("Home/{id}")]
        public IActionResult GetCategory(int? Id)
        {
            var totalmovie = _context.Movie.Include(x => x.Category).Include(x => x.Actor).Include(x => x.Rating).ToList();
            var slidermovie = _context.Movie.Take(2).Include(x => x.Category).Include(x => x.Actor).Include(x => x.Rating).ToList();
            var trendmovie = _context.Movie.OrderByDescending(x => x.IMDB).Take(2).Include(x => x.Actor).Include(x => x.Category).Include(x => x.Rating).ToList();
            var category = _context.Category.Where(x => x.Id ==Id).ToList();
            var category_name = category.ElementAt(0).Name;
            HomeViewModel homeview = new HomeViewModel(totalmovie, trendmovie, slidermovie,category_name);
            return View("Index",homeview);
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

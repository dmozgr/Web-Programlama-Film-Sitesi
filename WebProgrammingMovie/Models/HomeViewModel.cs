using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgrammingMovie.Models
{
    public class HomeViewModel
    {
        public List<Movie> _TotalMovie { get; set; }
        public List<Movie> _TrendMovie { get; set; }
        public List<Movie> _SliderMovie { get; set; }

        public HomeViewModel(List<Movie> TotalMovie, List<Movie> TrendMovie, List<Movie> SliderMovie)
        {
            _TotalMovie = TotalMovie;
            _TrendMovie = TrendMovie;
            _SliderMovie = SliderMovie;
        }
    }
}

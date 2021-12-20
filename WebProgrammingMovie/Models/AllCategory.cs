using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebProgrammingMovie.Models
{
    public class AllCategory
    {
        public AllCategory(List<Category> categories)
        {
            _categories = categories;
        }
        public List<Category> _categories { get; set; }
    }
}

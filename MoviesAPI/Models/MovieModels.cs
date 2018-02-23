using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API.Models
{
    public class Query
    {
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Genres { get; set; }
    }
}

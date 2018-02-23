using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Movies.Model.Entities {
    public class Movie : IEntityBase {
        public int Id { get; set; }
        public string Title { get; set; }
        public int YearOfRelease { get; set; }
        public int RunningTime { get; set; }
        public double AverageRating { get; set; }

        public ICollection<Genre> Genres { get; set; }

        [JsonIgnore]
        public ICollection<Rating> Ratings { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Model.Entities {
    public class Genre : IEntityBase {
        public int Id { get; set; }
        public string Title { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
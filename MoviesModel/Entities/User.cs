using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.Model.Entities {
    public class User : IEntityBase {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public ICollection<Rating> Ratings { get; set; }
    }
}
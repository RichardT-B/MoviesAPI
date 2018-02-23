using Movies.Data.Abstract;
using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Movies.Data.Repositories {
    public class GenreRepository : EntityBaseRepository<Genre>, IGenreRepository {
        public GenreRepository( MoviesContext context ) : base( context ) { }
    }
}

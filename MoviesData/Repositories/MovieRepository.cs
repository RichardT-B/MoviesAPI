using Movies.Data.Abstract;
using Movies.Model;
using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Movies.Data.Repositories {
    public class MovieRepository : EntityBaseRepository<Movie>, IMovieRepository {
        public MovieRepository( MoviesContext context ) : base( context ) { }

        public IEnumerable<Movie> Top( ) {
            return _context.Set<Movie>( )
                .OrderByDescending( m => m.AverageRating )
                .ThenBy( m => m.Title )
                .Take( 5 );
        }
        public IEnumerable<Movie> Query( Expression<Func<Movie, bool>> predicate ) {
            return _context.Set<Movie>( )
                .Include( m => m.Genres )
                .Where( predicate );
        }
    }
}
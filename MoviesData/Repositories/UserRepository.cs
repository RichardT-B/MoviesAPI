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
    public class UserRepository : EntityBaseRepository<User>, IUserRepository {
        public UserRepository( MoviesContext context ) : base( context ) { }

        public IEnumerable<Movie> Top( int id ) {
            var user = _context.Set<User>( )
                //.Include( u => u.Ratings )
                //.Include( "Ratings.Movie" )
                .FirstOrDefault( u => u.Id == id );

            if ( user == null )
                throw new ArgumentException( "User does not exist", "User Id" );

            if ( user.Ratings != null && user.Ratings.Any( ) ) {
                return user.Ratings
                    .OrderByDescending( r => r.Value )
                    .ThenBy( r => r.Movie.Title )
                    .Take( 5 )
                    .Select( r => r.Movie );
            }

            return null;
        }
    }
}

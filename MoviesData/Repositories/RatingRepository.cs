using Movies.Data.Abstract;
using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Movies.Data.Repositories {
    public class RatingRepository : EntityBaseRepository<Rating>, IRatingRepository {
        public RatingRepository( MoviesContext context ) : base( context ) { }

        public override void Add( Rating entity ) {
            base.Add( entity );
            
            var user = _context.Set<User>( )
                .Include(u => u.Ratings)
                .FirstOrDefault( u => u.Id == entity.UserId );

            //user.Ratings.Add( entity );

            _context.Set<User>( )
                .Update( user );

            var movie = _context.Set<Movie>( )
                .Include( m => m.Ratings )
                .FirstOrDefault( m => m.Id == entity.MovieId );

            //movie.Ratings.Add( entity );

            movie.AverageRating = 
                movie.Ratings.Average( r => r.Value );

            _context.Set<Movie>( )
                .Update( movie );
        }

        public override void Update( Rating entity ) {
            base.Update( entity );
            
            var movie = _context.Set<Movie>( )
                .Include( m => m.Ratings )
                .FirstOrDefault( m => m.Id == entity.MovieId );

            movie.AverageRating = 
                movie.Ratings.Average( r => r.Value );

            _context.Set<Movie>( )
                .Update( movie );
        }

        public Rating Get( int uId, int mId ) {
            return _context.Set<Rating>( )
                .FirstOrDefault( r => r.UserId == uId && r.MovieId == mId );
        }
    }
}

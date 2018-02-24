using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Movies.API.Models;
using Movies.Data.Abstract;
using Movies.Model.Entities;

namespace Movies.API.Controllers
{
    [Route("api/[controller]")]
    public class MovieController : Controller {
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;
        private IRatingRepository _ratingRepository;

        public MovieController( IMovieRepository movieRepository,
                                 IUserRepository userRepository,
                                 IRatingRepository ratingRepository ) {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _ratingRepository = ratingRepository;
        }

        // GET api/values
        [HttpGet( Name = "QueryMovies" ) ]
        public IActionResult Query( Query query ) {
            // Check at least one query option is submitted
            if ( query.Title == null && query.Year == null && query.Genres == null )
                return BadRequest( );

            // Process the list of Genres, separated by a semi-colon
            string[] genres = null;
            if ( query.Genres != null )
                genres = query.Genres.Split( ';' );
            
            // Run the query for the Movies
            var movies = _movieRepository.Query( m => ( query.Title == null || m.Title.Contains( query.Title ) ) &&
                                                      ( query.Genres == null || m.Genres.Select( g => g.Title ).Intersect( genres ).Count( ) == genres.Count( ) ) &&
                                                      ( query.Year == null || m.YearOfRelease == query.Year ) );

            // Check if any Movies have been found
            if ( movies is null || movies.Count( ) == 0 )
                return NotFound( );

            // Return a list of Movies found
            return Json( movies );
        }

        // GET api/values
        [HttpGet( "top", Name = "GetTop5Movies" )]
        public IActionResult Top( ) {
            // Get the top 5 rated Movies
            var movies = _movieRepository.Top( );

            // Check if any Movies have been found
            if ( movies is null || movies.Count( ) == 0 )
                return NotFound( );

            // Return the top 5 rated Movies
            return Json( movies );
        }
    }
}

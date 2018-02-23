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
            if ( query.Title == null && query.Year == null && query.Genres == null )
                return BadRequest( );

            string[] genres = null;
            if ( query.Genres != null )
                genres = query.Genres.Split( ';' );
            
            var movies = _movieRepository.Query( m => ( query.Title == null || m.Title.Contains( query.Title ) ) &&
                                                      ( query.Genres == null || m.Genres.Select( g => g.Title ).Intersect( genres ).Count( ) == genres.Count( ) ) &&
                                                      ( query.Year == null || m.YearOfRelease == query.Year ) );

            return Json( movies );
        }

        // GET api/values
        [HttpGet( "top", Name = "GetTopMovies" )]
        public IActionResult Top( ) {
            return Json( _movieRepository.Top( ) );
        }
    }
}

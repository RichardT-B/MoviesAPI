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
    public class UserController : Controller {
        private IMovieRepository _movieRepository;
        private IUserRepository _userRepository;
        private IRatingRepository _ratingRepository;

        public UserController( IMovieRepository movieRepository,
                               IUserRepository userRepository,
                               IRatingRepository ratingRepository ) {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
            _ratingRepository = ratingRepository;
        }
        
        // GET api/values
        [HttpGet("{id}/top",Name = "GetUserTop5Movies") ]
        public IActionResult Top( int id ) {
            // Check if the User exists
            if ( !_userRepository.Exists( id ) )
                return NotFound( );

            // Get the top 5 rated movies for the User
            var movies = _userRepository.Top( id );

            // Check if any Movies have been found
            if ( movies is null || movies.Count( ) == 0 )
                return NotFound( );

            // Return the top 5 rated Movies
            return Json( movies );
        }

        // GET api/values
        [HttpPost("{uId}/rate/{mId}",Name = "SetRating")]
        public IActionResult Rate( int uId, int mId, [FromBody]int rating ) {
            // Check if the rating is of a correct value
            if ( rating < 0 || rating > 5 )
                return BadRequest( );

            // Check that both the User and Movie exists
            if ( !_userRepository.Exists( uId ) ||
                 !_movieRepository.Exists( mId ) )
                return NotFound( );

            // Attempt to get an existing rating
            var r = _ratingRepository.Get( uId, mId );
            if ( r is null ) {
                // Add a new rating if one doesn't already exist
                _ratingRepository.Add( new Rating {
                    UserId = uId,
                    MovieId = mId,
                    Value = rating
                } );
            } else {
                // Update the existing rating
                r.Value = rating;
                _ratingRepository.Update( r );
            }

            // Commit the changes to the repository
            _ratingRepository.Commit( );

            // Return OK(200) when the function is successful
            return Ok( );
        }
    }
}

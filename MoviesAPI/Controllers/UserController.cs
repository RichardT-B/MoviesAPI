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
        [HttpGet("{id}/top",Name = "GetUserTopMovies") ]
        public IActionResult Top( int id ) {
            try {
                Movie[] movies = _userRepository.Top( id ).ToArray( );

                if ( movies == null )
                    return Json( new { } );

                return Json( movies );
            } catch ( ArgumentException ) {
                return BadRequest( );
            }
        }

        // GET api/values
        [HttpPost("{uId}/rate/{mId}",Name = "SetRating")]
        public IActionResult Rate( int uId, int mId, [FromBody]string rating ) {
            try {
                int ratingValue;
                if ( !int.TryParse( rating, out ratingValue ) )
                    return BadRequest( );

                var r = _ratingRepository.Get( uId, mId );
                if ( r != null ) {
                    r.Value = ratingValue;

                    _ratingRepository.Update( r );
                } else
                    _ratingRepository.Add( new Rating {
                        UserId = uId,
                        MovieId = mId,
                        Value = ratingValue
                    } );

                _ratingRepository.Commit( );

                return Ok( );
            } catch ( ArgumentException ) {
                return BadRequest( );
            }
        }
    }
}

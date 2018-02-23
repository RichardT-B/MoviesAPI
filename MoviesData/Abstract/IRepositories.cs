using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movies.Data.Abstract {
    public interface IMovieRepository : IEntityBaseRepository<Movie> {
        IEnumerable<Movie> Top( );
        IEnumerable<Movie> Query( Expression<Func<Movie, bool>> predicate );
    }
    public interface IUserRepository : IEntityBaseRepository<User> {
        IEnumerable<Movie> Top( int id );
    }
    public interface IRatingRepository : IEntityBaseRepository<Rating> {
        Rating Get( int uId, int mId );
    }
    public interface IGenreRepository : IEntityBaseRepository<Genre> { }
}

using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MoviesData
{
    public interface IMovieRepository : IEntityBaseRepository<Movie> { }
    public interface IUserRepository : IEntityBaseRepository<User> { }
    public interface IRatingRepository : IEntityBaseRepository<Rating> { }
}

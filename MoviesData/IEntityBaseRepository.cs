using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoviesData
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() {
        void Add( T entity );
    }
}

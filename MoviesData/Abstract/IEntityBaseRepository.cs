using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Movies.Data.Abstract {
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new() {
        bool Exists( int id );
        T Get( int id );

        void Add( T entity );
        void Update( T entity );
        void Commit( );
    }
}
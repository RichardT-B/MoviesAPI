using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movies.Data.Abstract;
using Movies.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data.Repositories {
    public class EntityBaseRepository<T> : IEntityBaseRepository<T>
            where T : class, IEntityBase, new() {
        internal MoviesContext _context;
        public EntityBaseRepository( MoviesContext context ) {
            _context = context;
        }

        public bool Exists( int id ) {
            return _context.Set<T>( )
                .Any( x => x.Id == id );
        }
        public T Get( int id ) {
            return _context.Set<T>( )
                .FirstOrDefault( x => x.Id == id );
        }

        public virtual void Add( T entity ) {
            EntityEntry dbEntityEntry = _context.Entry<T>( entity );
        }
        public virtual void Update( T entity ) {
            EntityEntry dbEntityEntry = _context.Entry<T>( entity );
            dbEntityEntry.State = EntityState.Modified;
        }
        
        public virtual void Commit( ) {
            _context.SaveChanges( );
        }
    }
}
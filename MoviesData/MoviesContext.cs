using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.SqlServer.Server;
using Microsoft.EntityFrameworkCore.Storage;
using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Movies.Data {
    public class MoviesContext : DbContext {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public MoviesContext( DbContextOptions options ) : base( options ) { }

        protected override void OnModelCreating( ModelBuilder modelBuilder ) {
            foreach ( var relationship in modelBuilder.Model.GetEntityTypes( ).SelectMany( e => e.GetForeignKeys( ) ) )
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            modelBuilder.Entity<Genre>( )
            .Property( g => g.Title )
            .IsRequired( );

            modelBuilder.Entity<Genre>( )
            .HasOne( g => g.Movie )
            .WithMany( m => m.Genres )
            .HasForeignKey( g => g.MovieId );

            modelBuilder.Entity<Rating>( )
            .Property( r => r.Value )
            .IsRequired( );

            modelBuilder.Entity<Rating>( )
            .HasOne( r => r.Movie )
            .WithMany( m => m.Ratings )
            .HasForeignKey( r => r.MovieId );

            modelBuilder.Entity<Rating>( )
            .HasOne( r => r.User )
            .WithMany( u => u.Ratings )
            .HasForeignKey( r => r.UserId );

            modelBuilder.Entity<Movie>( )
            .Property( m => m.Title )
            .IsRequired( );
            
            modelBuilder.Entity<Movie>( )
            .Property( m => m.YearOfRelease )
            .IsRequired( );

            modelBuilder.Entity<Movie>( )
            .Property( m => m.RunningTime )
            .IsRequired( );

            modelBuilder.Entity<Movie>( )
            .HasMany( m => m.Genres )
            .WithOne( g => g.Movie )
            .HasForeignKey( g => g.MovieId );

            modelBuilder.Entity<Movie>( )
            .Property( m => m.AverageRating );

            modelBuilder.Entity<Movie>( )
            .HasMany( m => m.Ratings )
            .WithOne( r => r.Movie )
            .HasForeignKey( r => r.MovieId );

            modelBuilder.Entity<User>( )
            .Property( u => u.Name )
            .IsRequired( );

            modelBuilder.Entity<User>( )
            .HasMany( m => m.Ratings )
            .WithOne( r => r.User )
            .HasForeignKey( r => r.UserId );
        }
    }
}

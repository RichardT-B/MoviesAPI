using Movies.Data;
using Movies.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movies.API {
    public class MoviesInitializer {
        private static MoviesContext context;
        public static void Initialize( IServiceProvider serviceProvider ) {
            context = (MoviesContext)serviceProvider.GetService( typeof( MoviesContext ) );

            InitializeUsers( );
            InitializeMovies( );
        }

        private static void InitializeUsers( ) {
            if ( !context.Users.Any( ) ) {
                User user1 = new User { Name = "Jaxon Glazier" };
                User user2 = new User { Name = "Dory Ramsey" };
                User user3 = new User { Name = "Laurel Harlan" };
                User user4 = new User { Name = "Delroy Statham" };
                User user5 = new User { Name = "Suzanne Siddall" };
                User user6 = new User { Name = "Suz Truman" };

                context.Users.Add( user1 );
                context.Users.Add( user2 );
                context.Users.Add( user3 );
                context.Users.Add( user4 );
                context.Users.Add( user5 );
                context.Users.Add( user6 );

                context.SaveChanges( );
            }
        }

        private static void InitializeMovies( ) {
            if ( !context.Movies.Any( ) ) {
                Movie movie1 = new Movie {
                    Title = "Righteous",
                    RunningTime = 138,
                    YearOfRelease = 2015,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Action"
                        },
                        new Genre {
                            Title = "Thriller"
                        }
                    }
                };

                Movie movie2 = new Movie {
                    Title = "Spot",
                    RunningTime = 95,
                    YearOfRelease = 2003,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Sci-Fi"
                        }
                    }
                };

                Movie movie3 = new Movie {
                    Title = "Shopping day",
                    RunningTime = 87,
                    YearOfRelease = 2004,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Family"
                        },
                        new Genre {
                            Title = "Animation"
                        }
                    }
                };

                Movie movie4 = new Movie {
                    Title = "Loved'n'Lost",
                    RunningTime = 104,
                    YearOfRelease = 2015,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Romance"
                        },
                        new Genre {
                            Title = "Comedy"
                        }
                    }
                };

                Movie movie5 = new Movie {
                    Title = "Friends",
                    RunningTime = 96,
                    YearOfRelease = 1975,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Comedy"
                        }
                    }
                };

                Movie movie6 = new Movie {
                    Title = "Dragon Spell",
                    RunningTime = 162,
                    YearOfRelease = 2009,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Fantasy"
                        },
                        new Genre {
                            Title = "Adventure"
                        },
                        new Genre {
                            Title = "Animation"
                        }
                    }
                };

                Movie movie7 = new Movie {
                    Title = "Slasher",
                    RunningTime = 127,
                    YearOfRelease = 2013,
                    Genres = new List<Genre>( ) {
                        new Genre {
                            Title = "Comedy"
                        },
                        new Genre {
                            Title = "Horror"
                        }
                    }
                };

                context.Movies.Add( movie1 );
                context.Movies.Add( movie2 );
                context.Movies.Add( movie3 );
                context.Movies.Add( movie4 );
                context.Movies.Add( movie5 );
                context.Movies.Add( movie6 );
                context.Movies.Add( movie7 );

                context.SaveChanges( );
            }
        }
    }
}
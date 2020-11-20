using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;

namespace FlexApp
{
     public static class MovieViewer
    {
        public static List<Movie> DisplayedMovies { get; set; }

        public static Context ct = new Context();

        public static void LoadPopularMovies() { DisplayedMovies = ct.Movies.OrderBy(x => x.Rating).Take(10).ToList(); }

        public static void LoadNewMovies() { DisplayedMovies = ct.Movies.OrderBy(x => x.Year).Take(10).ToList(); }

        public static void LoadMoviesByGenre(string genre) { DisplayedMovies = ct.Movies.Where(m=>m.Genre == genre).OrderBy(x => x.Rating).Take(10).ToList(); }

    }
}

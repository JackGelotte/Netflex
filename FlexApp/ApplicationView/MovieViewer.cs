using System;
using System.Linq;
using System.Collections.Generic;
using DatabaseConnection;

namespace FlexApp
{
    public static class MovieViewer
    {
        public const int MOVIES_PER_PAGE = 15;

        public static List<Movie> DisplayMovies { get; set; } = new List<Movie>();


        public static Context ct = new Context();

        public static void SearchMovie(string input)
        {
            DisplayMovies.Clear();
            DisplayMovies.AddRange(
                ct.Movies.Where(m => m.Title.Contains(input)
                || m.Genre.Contains(input)
                || m.Year == Int32.Parse(input))
                .OrderBy(x => x.Rating));
        }

        public static void LoadPopularMovies()
        {
            DisplayMovies.Clear();
            DisplayMovies.AddRange(ct.Movies.OrderBy(x => x.Rating).Take(MOVIES_PER_PAGE));
        }

        public static void LoadNewMovies()
        {
            DisplayMovies.Clear();
            DisplayMovies.AddRange(ct.Movies.OrderBy(x => x.Year).Take(MOVIES_PER_PAGE));
        }

        public static void LoadMoviesByGenre(string genre)
        {
            DisplayMovies.Clear();
            DisplayMovies.AddRange(ct.Movies.Where(x => x.Genre.Contains(genre)));
        }

    }

}

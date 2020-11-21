using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using System.Collections.ObjectModel;

namespace FlexApp
{
    public static class MovieViewer
    {
        public const int MOVIES_PER_PAGE = 15;

        public static Queue<Movie> DisplayMovies { get; set; } = new Queue<Movie>();

        public static Queue<Movie> HoldPrevious { get; set; } = new Queue<Movie>();

        public static Context ct = new Context();

        public static void SearchMovie(string input)
        {
            ct.Movies.Where(m => m.Title.Contains(input)
                || m.Genre.Contains(input)
                || m.Year == Int32.Parse(input))
                .OrderBy(x => x.Rating)
                .ToList()
                .ForEach(m => DisplayMovies.Enqueue(m));
        }

        public static void LoadPopularMovies()
        {
            ct.Movies.OrderBy(x => x.Rating).Take(MOVIES_PER_PAGE).ToList().ForEach(m => DisplayMovies.Enqueue(m));
        }

        public static void LoadNewMovies()
        {
            ct.Movies.OrderBy(x => x.Year).Take(MOVIES_PER_PAGE).ToList().ForEach(m => DisplayMovies.Enqueue(m));
        }

        public static void LoadMoviesByGenre(string genre)
        {
            ct.Movies.Where(x => x.Genre.Contains(genre)).ToList().ForEach(m => DisplayMovies.Enqueue(m));
            Franco1 f1 = new Franco1();
            f1.InitializeComponent();
        }

        public static void ClearQueue()
        {
            DisplayMovies.Clear();
            HoldPrevious.Clear();
        }

    }
}

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;
using System.Collections.ObjectModel;

namespace FlexApp
{
    public class MovieViewer
    {
        public const int MOVIES_PER_PAGE = 10;

        public Queue<Movie> DisplayMovies { get; set; } = new Queue<Movie>();

        public Queue<Movie> HoldPrevious { get; set; } = new Queue<Movie>();

        public Context ct = new Context();

        public void SearchMovie(string input)
        {
            ct.Movies.Where(m => m.Title.Contains(input)
                || m.Genre.Contains(input)
                || m.Year == Int32.Parse(input))
                .OrderBy(x => x.Rating)
                .ToList()
                .ForEach(m => DisplayMovies.Enqueue(m));
        }

        public void LoadPopularMovies()
        {
            ct.Movies.OrderBy(x => x.Rating).Take(MOVIES_PER_PAGE).ToList().ForEach(m => DisplayMovies.Enqueue(m));
        }

        public void LoadNewMovies()
        {
            ct.Movies.OrderBy(x => x.Year).Take(MOVIES_PER_PAGE).ToList().ForEach(m => DisplayMovies.Enqueue(m));
        }

        public void LoadMoviesByGenre(string genre)
        {
            ct.Movies.Where(x => x.Genre.Contains(genre)).ToList().ForEach(m => DisplayMovies.Enqueue(m));
            Franco1 f1 = new Franco1();
            f1.InitializeComponent();
        }

        public void ClearQueue()
        {
            DisplayMovies.Clear();
            HoldPrevious.Clear();
        }

    }
}

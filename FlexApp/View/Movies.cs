using System;
using System.Linq;
using System.Collections.Generic;
using DatabaseConnection;
using System.Collections.ObjectModel;

namespace FlexApp
{
    public static class Movies
    {
        public const int MOVIES_PER_PAGE = 15;

        public static ObservableCollection<Movie> DisplayMovies { get; set; } = new ObservableCollection<Movie>();

        public static ObservableCollection<Movie> ActiveMovies { get; set; } = new ObservableCollection<Movie>();

        public static void SearchMovie(string input)
        {
            DisplayMovies.Clear();
            foreach (Movie m in Status.ct.Movies.AsEnumerable().Where(m => m.Title.Contains(input, StringComparison.OrdinalIgnoreCase)).OrderBy(x => x.Rating)) DisplayMovies.Add(m);
        }

        public static void LoadPopularMovies()
        {
            DisplayMovies.Clear();
            foreach (Movie m in Status.ct.Movies.OrderBy(x => x.Rating).Reverse()) DisplayMovies.Add(m);
        }

        public static void LoadNewMovies()
        {
            DisplayMovies.Clear();
            foreach (Movie m in Status.ct.Movies.OrderBy(x => x.Year).Reverse()) DisplayMovies.Add(m);
        }

        public static void LoadMoviesByGenre(string genre)
        {
            DisplayMovies.Clear();
            foreach (Movie m in Status.ct.Movies.Where(x => x.Genre.Contains(genre))) DisplayMovies.Add(m);
        }

        public static void LoadActiveMovies()
        {
            ActiveMovies.Clear();
            foreach (Movie m in Status.ct.Rentals.Where(x => x.Customer == Status.Customer && DateTime.Parse(x.ReturnDate) < DateTime.Now).Select(r=>r.Movie)) ActiveMovies.Add(m);
        }

        public static List<Movie> PageSort(int page) => DisplayMovies.Skip(page * MOVIES_PER_PAGE).ToList();

        public static IEnumerable<Movie> TestMethod(string title) => Status.ct.Movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).AsEnumerable();

    }

}

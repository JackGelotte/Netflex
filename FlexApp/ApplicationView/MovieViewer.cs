using System;
using System.Linq;
using System.Collections.Generic;
using DatabaseConnection;
using System.Collections.ObjectModel;

namespace FlexApp
{
    public static class MovieViewer
    {
        public const int MOVIES_PER_PAGE = 15;

        public static ObservableCollection<Movie> DisplayMovies { get; set; } = new ObservableCollection<Movie>();

        public static Context ct = new Context();

        public static void SearchMovie(string input)
        {
            DisplayMovies.Clear();
            foreach(Movie m in ct.Movies.AsEnumerable().Where(m => m.Title.Contains(input, StringComparison.OrdinalIgnoreCase)).OrderBy(x => x.Rating))
            {
                DisplayMovies.Add(m);
            }        
        }

        public static void LoadPopularMovies()
        {
            DisplayMovies.Clear();
            foreach (Movie m in ct.Movies.OrderBy(x => x.Rating).Take(MOVIES_PER_PAGE)) DisplayMovies.Add(m);
        }

        public static void LoadNewMovies()
        {
            DisplayMovies.Clear();
            foreach (Movie m in ct.Movies.OrderBy(x => x.Year).Take(MOVIES_PER_PAGE)) DisplayMovies.Add(m);
            
        }

        public static void LoadMoviesByGenre(string genre)
        {
            DisplayMovies.Clear();
            foreach(Movie m in ct.Movies.Where(x => x.Genre.Contains(genre))) DisplayMovies.Add(m);
        }


        public static List<Movie> PageSort(int page) => DisplayMovies.Skip(page * MOVIES_PER_PAGE).ToList();

        public static IEnumerable<Movie> TestMethod(string title) => ct.Movies.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).AsEnumerable();


    }

}

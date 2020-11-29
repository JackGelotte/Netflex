using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;
using TMDbLib;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace FlexApp
{
    public partial class MovieDisplay : UserControl
    {
        public static MovieDisplay MovieDisplayUserControl
        {
            get;
            private set;
        }

        public string UserControlName = "MDUC";

        public MovieDisplay()
        {
            if (MovieDisplayUserControl != null) throw new NotSupportedException();

            MovieDisplayUserControl = this;

            InitializeComponent();

            InitializeMovieView();

            DataContext = this;

        }

        public int Index = 0;

        private int page = 0;
        public int Page
        {
            get { return page; }
            set
            {
                if (value < 0) page = 0;
                else page = value;
            }
        }

        public static void Refresh()
        {
            MovieDisplayUserControl.MovieViewScroll.ScrollToVerticalOffset(0);

            MovieDisplayUserControl.MovieGrid.Children.Clear();

            MovieDisplayUserControl.InitializeMovieView();
        }

        public void InitializeMovieView()
        {
            if (Movies.DisplayMovies.Count > 0)
            {        
                for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
                {
                    for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                    {
                        if (Index < Movies.DisplayMovies.Count)
                        {
                            Movie m = Movies.DisplayMovies[Index];
                            StackPanel sp = new StackPanel();
                            TextBlock title = new TextBlock();
                            Image image = new Image();

                            TMDbClient client = new TMDbClient(Helper.TmdbApi.APIKey);
                            SearchContainer<SearchMovie> results = client.SearchMovieAsync(m.Title).Result;
                            try
                            {
                                var movieId = results.Results.Where(r => r.Title.Equals(m.Title, StringComparison.InvariantCultureIgnoreCase)).First().Id;
                                TMDbLib.Objects.Movies.Movie movie = client.GetMovieAsync(movieId).Result;
                                string baseUrl = "https://image.tmdb.org/t/p/";
                                string size = "w500"; // "w500" för mindre version / "orginal" för full storlek
                                string path = movie.PosterPath;
                                image.Source = new BitmapImage(new Uri($"{baseUrl}{size}{path}"));
                            }
                            catch
                            {
                                image.Source = new BitmapImage(new Uri(Helper.Image.BjornAvatarURL));
                            }

                            title.Cursor = Cursors.Wait;
                            title.Text = m.Title;
                            title.Foreground = Brushes.White;
                            title.FontSize = 20;
                            title.Margin = new Thickness(10, 0, 10, 10);
                            title.HorizontalAlignment = HorizontalAlignment.Center;

                            image.Cursor = Cursors.Wait;
                            image.Margin = new Thickness(10, 30, 10, 5);
                            image.MaxHeight = 280;

                            sp.Children.Add(image);
                            sp.Children.Add(title);

                            MovieGrid.Children.Add(sp);

                            sp.MouseUp += Mouse_Up;

                            Grid.SetRow(sp, y);
                            Grid.SetColumn(sp, x);

                            Index++;
                        }
                    }
                }
            }       
            else
            {
                // Text vid 0 resultat på sökning
                StackPanel sp = new StackPanel();

                TextBlock tb = new TextBlock();
                tb.Text = Helper.Message.SearchReturnedNoResultsLine1;
                tb.Background = Brushes.Black;
                tb.Foreground = Brushes.White;
                tb.FontSize = 35;
                tb.FontWeight = FontWeight.FromOpenTypeWeight(700);

                TextBlock tb2 = new TextBlock();
                tb2.Text = Helper.Message.SearchReturnedNoResultsLine2;
                tb2.Background = Brushes.Black;
                tb2.Foreground = Brushes.White;
                tb2.FontSize = 20;
                tb2.FontWeight = FontWeight.FromOpenTypeWeight(500);

                sp.Children.Add(tb);
                sp.Children.Add(tb2);

                MovieGrid.Children.Add(sp);

                Grid.SetRow(sp, 0);
                Grid.SetColumn(sp, 0);
                Grid.SetColumnSpan(sp, 4);               
            }
        }

        private void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            MovieFocus mf = new MovieFocus();

            // Referera klickad film till MovieFocus
            var y = Grid.GetRow(sender as UIElement);
            var x = Grid.GetColumn(sender as UIElement);
            int i = (y * MovieGrid.ColumnDefinitions.Count + x) + (Page * Movies.MOVIES_PER_PAGE);
            mf.MovieSelected = Movies.DisplayMovies[i];

            // API-call till TMDB
            // TMDB id från FilmTitel
            TMDbClient client = new TMDbClient(Helper.TmdbApi.APIKey);
            SearchContainer<SearchMovie> results = client.SearchMovieAsync(Movies.DisplayMovies[i].Title).Result;
            var movieId = results.Results.Where(m=>m.Title.Equals(Movies.DisplayMovies[i].Title, StringComparison.OrdinalIgnoreCase)).First().Id;

            TMDbLib.Objects.Movies.Movie movie = client.GetMovieAsync(movieId).Result;

            // Synopsis till MovieFocus
            mf.Synopsis.Text =  movie.Overview.Length < 350 ? movie.Overview : $"{movie.Overview.Substring(0, 349)}...";

            // General Info till MovieFocus
            mf.MovieNameYear.Text = $"{Movies.DisplayMovies[i].Title} " +
                $"({Movies.DisplayMovies[i].Year})";
            mf.MovieImdbRating.Text = $"IMDb Score : {Movies.DisplayMovies[i].Rating}";

            // Poster till MovieFocus
            string baseUrl = "https://image.tmdb.org/t/p/";
            string size = "original"; // "w500" för mindre version / "orginal" för full storlek
            string path = movie.PosterPath;

            mf.MoviePoster.Source = new BitmapImage(new Uri($"{baseUrl}{size}{path}"));

            //mf.TrailerRun.Trailer.Source = new Uri("");

            // Centrera fönstret till MainWindow
            MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized);
            mf.Width = mw.Width - 150;
            mf.Height = mw.Height - 90;
            mf.Owner = mw;
            mf.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mf.Show();
        }

        private void Click_Previous(object sender, RoutedEventArgs e)
        {
            Page--;
            Index = (Page * Movies.MOVIES_PER_PAGE);
            Refresh();          
        }

        private void Click_Next(object sender, RoutedEventArgs e)
        {
            Page++;
            Index = (Page * Movies.MOVIES_PER_PAGE);
            Refresh();            
        }

    }
}


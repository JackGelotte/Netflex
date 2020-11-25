using System;
using System.Collections.Generic;
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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MovieDisplay.xaml
    /// </summary>
    public partial class MovieDisplay : UserControl
    {
        private static int page = 1;

        private static int index = 0;
        public static int Page
        {
            get { return page; }
            set
            {
                if (value < 1) page = 1;
                else page = value;
            }
        }

        public void InitializeMovieView()
        {
            index = 0;

            for (int x = 0; x < MovieGrid.RowDefinitions.Count; x++)
            {
                for (int y = 0; y < MovieGrid.ColumnDefinitions.Count; y++)
                {
                    if (index < Movies.DisplayMovies.Count
                        && index < Page * Movies.MOVIES_PER_PAGE)
                    {
                        Movie m = Movies.DisplayMovies[index];

                        Image image = new Image();
                        image.Cursor = Cursors.Hand;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(m.PosterLink));
                        image.Margin = new Thickness(4, 4, 4, 4);
                        image.MouseUp += Mouse_Up;

                        MovieGrid.Children.Add(image);
                        Grid.SetRow(image, x);
                        Grid.SetColumn(image, y);
                        index++;
                    }  
                }
            }
        }

        public MovieDisplay()
        {
            InitializeComponent();

            InitializeMovieView();

        }

        private void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            MovieFocus md = new MovieFocus();

            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = y * MovieGrid.ColumnDefinitions.Count + x;
            md.MovieSelected = Movies.DisplayMovies[i];

            md.MoviePoster.Source = new BitmapImage(new Uri(Movies.DisplayMovies[i].PosterLink));
            md.MovieInfo.Text = $"{Movies.DisplayMovies[i].Title} " +
                $"{Movies.DisplayMovies[i].Year} " +
                $"{Movies.DisplayMovies[i].Rating}";

            md.Show();
        }

        private void Click_Previous(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Page--;
            MovieDisplay md = new MovieDisplay();
            md.Visibility = Visibility.Visible;
        }

        private void Click_Next(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            Page++;
            MovieDisplay md = new MovieDisplay();
            md.Visibility = Visibility.Visible;
        }
    }
}


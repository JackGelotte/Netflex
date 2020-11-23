using System;
using System.Collections.Generic;
using System.Net;
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
using System.Linq;


namespace FlexApp
{
    /// <summary>
    /// Interaction logic for Franco1.xaml
    /// </summary>
    public partial class Franco1 : Page
    {

        public static int Page
        {
            get { return Page; }
            set
            {
                if (value < 1) Page = 1;
                else Page = value;
            }
        }

        public void InitializeMovieView()
        {
            int i = 0 * Page;

            for (int x = 0; x < MovieGrid.RowDefinitions.Count; x++)
            {
                for (int y = 0; y < MovieGrid.ColumnDefinitions.Count; y++)
                {
                    if (i < MovieViewer.DisplayMovies.Count
                        && i < Page * MovieViewer.MOVIES_PER_PAGE)
                    {
                        Movie m = MovieViewer.DisplayMovies[i];

                        Image image = new Image();
                        image.Cursor = Cursors.Hand;
                        image.HorizontalAlignment = HorizontalAlignment.Center;
                        image.VerticalAlignment = VerticalAlignment.Center;
                        image.Source = new BitmapImage(new Uri(m.PosterLink));
                        image.Margin = new Thickness(4, 4, 4, 4);

                        MovieGrid.Children.Add(image);
                        Grid.SetRow(image, x);
                        Grid.SetColumn(image, y);
                    }
                    i++;
                }
            }
        }

        public Franco1()
        {
            InitializeComponent();

            InitializeMovieView();

        }

        private void Click_Previous(object sender, RoutedEventArgs e)
        {
            Page--;
            InitializeMovieView();
        }

        private void Click_Next(object sender, RoutedEventArgs e)
        {
            Page++;
            InitializeMovieView();
        }
    }
}

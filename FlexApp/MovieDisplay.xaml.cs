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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MovieDisplay.xaml
    /// </summary>
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

        }

        private static int index = 0;
        public static int Index
        {
            get { return index + Page * Movies.MOVIES_PER_PAGE; }
            set { index = value; }
        }
        
        private static int page = 0;
        public static int Page
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
            MovieDisplayUserControl.MovieGrid.Children.Clear();

            MovieDisplayUserControl.InitializeMovieView();
        }


        public void InitializeMovieView()
        {
            Index = 0;
            for (int y = 0; y < MovieGrid.RowDefinitions.Count; y++)
            {   for (int x = 0; x < MovieGrid.ColumnDefinitions.Count; x++)
                {   if (Index < Movies.DisplayMovies.Count)
                    {
                        Movie m = Movies.DisplayMovies[Index];

                        StackPanel SP = new StackPanel();
                        TextBlock title = new TextBlock();
                        Image image = new Image();
                        
                        title.Cursor = Cursors.Wait;
                        title.Text = m.Title;
                        title.Foreground = Brushes.White;
                        title.FontSize = 20;
                        title.Margin = new Thickness(10,0,10,10);
                        title.HorizontalAlignment = HorizontalAlignment.Center;
                        title.MouseUp += Mouse_Up;

                        image.Cursor = Cursors.Wait;
                        image.Source = new BitmapImage(new Uri(m.PosterLink));                    
                        image.Margin = new Thickness(10, 30, 10, 5);
                        image.MouseUp += Mouse_Up;
                        image.MaxHeight = 280;                       

                        SP.Children.Add(image);
                        SP.Children.Add(title);

                        MovieGrid.Children.Add(SP);

                        Grid.SetRow(SP, y);
                        Grid.SetColumn(SP, x);

                        index++;
                    }   
                }
            }
        }

        private void Mouse_Up(object sender, MouseButtonEventArgs e)
        {
            MovieFocus mf = new MovieFocus();
            MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized);

            mf.Width = mw.MainPage.Width - 20;
            mf.Height = mw.MainPage.Height - 20;
            mf.Owner =  mw;

            mf.WindowStartupLocation = WindowStartupLocation.CenterOwner;

            var x = Grid.GetColumn(sender as UIElement);
            var y = Grid.GetRow(sender as UIElement);

            int i = (x * MovieGrid.RowDefinitions.Count + y) + Page * Movies.MOVIES_PER_PAGE;

            mf.MovieSelected = Movies.DisplayMovies[i];

            mf.MoviePoster.Source = new BitmapImage(new Uri(Movies.DisplayMovies[i].PosterLink));
            mf.MovieInfo.Text = $"{Movies.DisplayMovies[i].Title} " +
                $"{Movies.DisplayMovies[i].Year} " +
                $"{Movies.DisplayMovies[i].Rating}";

            mf.Show();
        }

        private void Click_Previous(object sender, RoutedEventArgs e)
        {
            Page--;
            Refresh();
        }

        private void Click_Next(object sender, RoutedEventArgs e)
        {
            Page++;
            Refresh();
        }
    }
}


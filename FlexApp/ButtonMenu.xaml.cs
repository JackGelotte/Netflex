using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.EntityFrameworkCore;
using System.Windows.Markup;
using System.Collections.ObjectModel;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for ButtonMenu.xaml
    /// </summary>



    public partial class ButtonMenu : UserControl
    {

        Context ct = new Context();

        public ObservableCollection<Genre> GenresTest { get {
                return new ObservableCollection<Genre>() {
                        new Genre("Action"),
                        new Genre("Adventure"),
                        new Genre("Animation"),
                        new Genre("Biography"),
                        new Genre("Comedy"),
                        new Genre("Crime"),
                        new Genre("Documentary"),
                        new Genre("Drama"),
                        new Genre("Family"),
                        new Genre("Fantasy"),
                        new Genre("FilmNoir", "Film Noir"),
                        new Genre("History"),
                        new Genre("Horror"),
                        new Genre("Music"),
                        new Genre("Musical"),
                        new Genre("Mystery"),
                        new Genre("Romance"),
                        new Genre("SciFi", "Sci-Fi"),
                        new Genre("Short"),
                        new Genre("Sport"),
                        new Genre("Superhero"),
                        new Genre("Thriller"),
                        new Genre("War"),
                        new Genre("Western")
                };}
        }

        public class Genre
        {
            public string GenreName { get; set; }
            public string GenreShow { get; set; }
            public Genre(string value) { GenreName = value; GenreShow = value; }
            public Genre(string value, string show) { GenreName = value; GenreShow = show; }

        }

        public ButtonMenu()
        {
            InitializeComponent();

            DataContext = this;

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hot_Click(object sender, RoutedEventArgs e)
        {
            MovieViewer.LoadPopularMovies();
            MoviePage f1 = new MoviePage();

        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchBox.Text = "";
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                SearchBox.Text = "Search";
            }
           
        }

        private void GenresComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MovieViewer.LoadMoviesByGenre(GenresComboBox.Text);
        }
    }  
}

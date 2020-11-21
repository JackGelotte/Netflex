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
        public MovieViewer mv = new MovieViewer();

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
                        new Genre("FilmNoir"),
                        new Genre("History"),
                        new Genre("Horror"),
                        new Genre("Music"),
                        new Genre("Musical"),
                        new Genre("Mystery"),
                        new Genre("Romance"),
                        new Genre("SciFi"),
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
            public Genre(string value) { GenreName = value; }

        }

        public ButtonMenu()
        {
            InitializeComponent();

            DataContext = this;

        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hot_Click(object sender, RoutedEventArgs e)
        {
            mv.ClearQueue();
            mv.LoadPopularMovies();
        }

        private void GenresComboBox_Select(object sender, MouseButtonEventArgs e)
        {
            mv.ClearQueue();
            mv.LoadMoviesByGenre(GenresComboBox.SelectedItem.ToString());
        }
    }  
}

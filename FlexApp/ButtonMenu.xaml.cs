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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for ButtonMenu.xaml
    /// </summary>
    public partial class ButtonMenu : UserControl
    {
        public const int BUTTON_SEPARATOR = 150;

        public ButtonMenu()
        {
            InitializeComponent();


            // Genres.ItemsSource = Enum.GetValues(typeof(Genre)).Cast<Genre>();

            //Context ct = new Context();

            //Genres.ItemsSource = ct.Movies.ToList();

            // typeof(Colors).GetProperties();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        string SelectedGenre = "Action";
        public static int GetEnum(string value)
        {
            try
            {
                return (int)Enum.Parse(typeof(Genre), Regex.Replace(value, "[ -]", ""));
            }
            catch { return 24; }
        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {
            MovieViewer.LoadMoviesByGenre(GetEnum(SelectedGenre));
        }

        private void Hot_Click(object sender, RoutedEventArgs e)
        {
            MovieViewer.LoadPopularMovies();
        }

    }  
}

using DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlexApp.User;
using System.Collections.ObjectModel;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            MovieViewer.LoadNewMovies();

            InitializeComponent();
            
            



            if (!UserSession.IsLoggedIn)
            {
                Login_Logout_ButtonText.Text = "Login";
                Register_MyPage_ButtonText.Text = "Register";
            }

            if (UserSession.IsLoggedIn)
            {
                Login_Logout_ButtonText.Text = "Log Out";
                Register_MyPage_ButtonText.Text = "My Page";
            }
        }

        // Logo Knapp
        private void LogoButton_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Visibility = Visibility.Visible;
            RegistrationPage.Visibility = Visibility.Hidden;
        }


        // Login Knapp
        private void Login_Logout_Click(object sender, RoutedEventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                LoginScreen ls = new LoginScreen();
                ls.Show();
            }

            if (UserSession.IsLoggedIn)
            {

            }
        }

        // Registrering Knapp
        private void Register_MyPage_Click(object sender, RoutedEventArgs e)
        {
            if (!UserSession.IsLoggedIn)
            {
                StartPage.Visibility = Visibility.Hidden;
                RegistrationPage.Visibility = Visibility.Visible;
            }

            if (UserSession.IsLoggedIn)
            {

            }
        }

        // Genre Lista
        public ObservableCollection<Genre> GenresTest
        {
            get
            {
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
                };
            }
        }
        public class Genre
        {
            public string GenreName { get; set; }
            public string GenreShow { get; set; }
            public Genre(string value) { GenreName = value; GenreShow = value; }
            public Genre(string value, string show) { GenreName = value; GenreShow = show; }

        }
        private void GenresComboBox_DropDownClosed(object sender, EventArgs e)
        {
            MovieViewer.LoadMoviesByGenre(GenresComboBox.Text);
        }

        // Sök Knapp
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MovieViewer.SearchMovie(SearchBox.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show($"{Helper.Message.SearchErrorIncorectSearchTerm}\n{exc}");
            }
        }
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search") SearchBox.Text = "";
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                SearchBox.Text = "Search";
            }

        }

        // Hot! Knapp
        private void Hot_Click(object sender, RoutedEventArgs e)
        {
            MovieViewer.LoadPopularMovies();

        }

        
    }

    }

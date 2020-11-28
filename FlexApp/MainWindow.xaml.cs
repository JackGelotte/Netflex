using DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlexApp.User;
using System.Collections.ObjectModel;
using System.Threading;
using System.Drawing;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Movies.LoadNewMovies();

            this.InitializeComponent();

            DataContext = this;
        }

        public static void Refresh()
        {
            MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault(x => x.IsInitialized);

            if (!Status.IsLoggedIn)
            {
                mw.Login_Logout_ButtonText.Text = "Login";
                mw.Register_MyPage_ButtonText.Text = "Register";
            }
            if (Status.IsLoggedIn)
            {
                mw.Login_Logout_ButtonText.Text = "Log Out";
                mw.Register_MyPage_ButtonText.Text = "My Page";
            }
        }

        // Login Knapp
        private void Login_Logout_Click(object sender, RoutedEventArgs e)
        {
            if (!Status.IsLoggedIn)
            {
                /*
                LoginScreen ls = new LoginScreen(); 
                ls.Owner = this;
                ls.WindowStartupLocation = WindowStartupLocation.Manual;
                ls.Left = 1;
                ls.Top = 1;
                ls.Show();
                */

                LoginDropDown.Visibility = Visibility.Visible;

            }

            if (Status.IsLoggedIn)
            {
                Status.LogOut();
                HomePage();
                Login_Logout_ButtonText.Text = "Login";
                Register_MyPage_ButtonText.Text = "Register";
            }
        }

        // Registrering Knapp
        private void Register_MyPage_Click(object sender, RoutedEventArgs e)
        {
            if (!Status.IsLoggedIn)
            {

                StartPage.Visibility = Visibility.Hidden;
                UserPage.Visibility = Visibility.Hidden;
                RegistrationPage.Visibility = Visibility.Visible;
                AboutPage.Visibility = Visibility.Hidden;
                LoginDropDown.Visibility = Visibility.Hidden;
            }

            if (Status.IsLoggedIn)
            {
                StartPage.Visibility = Visibility.Hidden;
                RegistrationPage.Visibility = Visibility.Hidden;
                UserPage.Visibility = Visibility.Visible;
                AboutPage.Visibility = Visibility.Hidden;
                LoginDropDown.Visibility = Visibility.Hidden;
            }
        }
        private void About_Click(object sender, RoutedEventArgs e)
        {
            StartPage.Visibility = Visibility.Hidden;
            RegistrationPage.Visibility = Visibility.Hidden;
            UserPage.Visibility = Visibility.Hidden;
            AboutPage.Visibility = Visibility.Visible;
            LoginDropDown.Visibility = Visibility.Hidden;

        }

        // Logo Knapp
        private void Logo_Click(object sender, MouseButtonEventArgs e)
        {
            HomePage();
        }

        public void HomePage()
        {
            LoginDropDown.Visibility = Visibility.Hidden;
            StartPage.Visibility = Visibility.Visible;
            RegistrationPage.Visibility = Visibility.Hidden;
            UserPage.Visibility = Visibility.Hidden;
            AboutPage.Visibility = Visibility.Hidden;         
            Movies.LoadNewMovies();
            MovieDisplay.Refresh();
        }

        // Genre Lista
        public ObservableCollection<Genre> Genres {
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
            HomePage();
            Movies.LoadMoviesByGenre(GenresComboBox.Text);
            MovieDisplay.Page = 0;
            MovieDisplay.Refresh();
        }

        private void Hot_Click(object sender, RoutedEventArgs e)
        {
            HomePage();
            Movies.LoadPopularMovies();
            MovieDisplay.Page = 0;
            MovieDisplay.Refresh();
        }


    }
}

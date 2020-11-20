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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Context ct = new Context();

        private UserSession user = new UserSession();
        
        private List<Movie> FrontPageMovies { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            UserSession currentSession = new UserSession();

            LoadFrontPageMovies();

        }

        public void LoadFrontPageMovies() { FrontPageMovies = ct.Movies.OrderBy(x => x.Rating).Take(10).ToList(); }
























        public List<string> Options = new List<string> { "Title", "Genre", "Year" };

        public List<Movie> SearchResults = new List<Movie>();

        public void Click_Search_Options(object e)
        {
            bool buttonClicked = true;
            buttonClicked = ReverseBool(buttonClicked);
            if (buttonClicked) ;// Options.Add( Name of click )
            if (!buttonClicked) ; // Option.Remove( Name of click )

        }

        public void Click_Search(object e)
        {       
            AppRental ar = new AppRental(user);

            string searchTerm = "Titanic";

            foreach (string s in Options) SearchResults.AddRange(Search.ShowResult(searchTerm, s));





            int daysActive = 1; // 1, 3, 7

            ar.RegisterRental(SearchResults.First(), daysActive);

        }

        public bool ReverseBool(bool b) => b == true ? false : true;
    }
}

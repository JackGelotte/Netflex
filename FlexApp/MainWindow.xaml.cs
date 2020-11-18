using DatabaseConnection;
using FlexApp.User;
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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserStatus user = new UserStatus();

        public MainWindow()
        {
            InitializeComponent();
            
        }



        public bool[] options = { true, true, true, true, true };
        public void Click_Search_Options()
        {

        }

        public void Click_Search(object e)
        {       
            UserRental ur = new UserRental(user);

            ur.RegisterRental(UserSearch.Search("Titanic", options));

            
        }
    }
}

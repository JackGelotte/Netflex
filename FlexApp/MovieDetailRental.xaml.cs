using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DatabaseConnection;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for MovieDetailRental.xaml
    /// </summary>
    public partial class MovieDetailRental : Window
    {

        public ObservableCollection<DaysActiveComboBox> DaysActiveSelection { get {
            return new ObservableCollection<DaysActiveComboBox>() { 
            new DaysActiveComboBox(1),
            new DaysActiveComboBox(3),
            new DaysActiveComboBox(7)
            }; }
        }

        public class DaysActiveComboBox
        {
            public int DaysActive { get; set; }
            public DaysActiveComboBox(int i) { DaysActive = i; }

        }

        public Movie MovieToRent { get; set; }

        public MovieDetailRental()
        {
            InitializeComponent();
            
        }

        private void Rent_Button_Click(object sender, RoutedEventArgs e)
        {
            if(!UserSession.IsLoggedIn)
            {
                LoginScreen ls = new LoginScreen();
                ls.Show();
            }

            if(UserSession.IsLoggedIn)
            {
                User.AppRental ar = new User.AppRental();
                ar.RegisterRental(MovieToRent, 1);

                this.Close();
            }


        }
    }
}

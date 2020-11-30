using System;
using System.Linq;
using System.Collections.Generic;
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
    public partial class UserPage : UserControl
    {

        public static UserPage UserPageUserControl
        {
            get;
            private set;
        }

        public string UserControlName = "UPUC";

        public UserPage()
        {
            if (UserPageUserControl != null) throw new NotSupportedException();

            UserPageUserControl = this;

            InitializeComponent();

            AvatarImage.Source = new BitmapImage(new Uri(Helper.Image.BjornAvatarURL));

        }

        public void Refresh()
        {
            // Refresh Users Rental count
            RentalsCount.Text = $"{Status.ct.Rentals.Where(r => r.Customer.Equals(Status.Customer)).Count()}";

            // Refresh Users Rental History
            foreach (Rental r in Status.ct.Rentals.Where(x => x.Customer == Status.Customer))
            {
                if (!UserPageUserControl.ActiveRentalsUserControl.ActiveMovies.Contains(r))
                {
                    UserPageUserControl.RentalsHistoryUserControl.RentalHistoryListView
                    .Insert(0, new UserPageRentalsHistory.MovieHistory($"{r.Movie.Title}", $"{r.RentDate}", $"{r.ReturnDate}"));
                }
            }

            // Refresh Users Active Rentals
            UserPageUserControl.ActiveRentalsUserControl.MovieGrid.Children.Clear();
            foreach (Rental r in Status.ct.Rentals.Where(x => x.Customer == Status.Customer).OrderBy(o => o.RentDate))
            {
                if (DateTime.Parse(r.ReturnDate) > DateTime.Now)
                {
                    if(!UserPageUserControl.ActiveRentalsUserControl.ActiveMovies.Contains(r))
                    {
                        UserPageUserControl.ActiveRentalsUserControl.ActiveMovies.Insert(0, r);
                    }                   
                }
            }
            UserPageUserControl.ActiveRentalsUserControl.Refresh();

            // Refresh Avatar
            try
            {
                this.AvatarImage.Source = new BitmapImage(new Uri(Status.Customer.AvatarUrl));
            }
            catch
            {
                this.AvatarImage.Source = new BitmapImage(new Uri(Helper.Image.DefaultAvatarURL));
            }

            // Refresh User Information for UserPage
            var adress = Status.Customer.Adress.Split(' ');

            UserPageUserControl.AccountInfoUserControl.FirstName.Text = Status.Customer.FirstName;
            UserPageUserControl.AccountInfoUserControl.LastName.Text = Status.Customer.LastName;
            UserPageUserControl.AccountInfoUserControl.Street.Text = adress[0];
            UserPageUserControl.AccountInfoUserControl.Postal.Text = $"{adress[1]} {adress[2]}";
            UserPageUserControl.AccountInfoUserControl.City.Text = adress[3];
            UserPageUserControl.AccountInfoUserControl.State.Text = adress[4];
            UserPageUserControl.AccountInfoUserControl.Email.Text = Status.Customer.Email;
            UserPageUserControl.AccountInfoUserControl.PhoneNo.Text = Status.Customer.PhoneNumber;
            UserPageUserControl.AccountInfoUserControl.Username.Text = Status.Customer.Login.Username;
            UserPageUserControl.AccountInfoUserControl.Password.Password = "";
            UserPageUserControl.AccountInfoUserControl.PasswordRepeat.Password = "";

        }

        private void ActiveRentals_Click(object sender, RoutedEventArgs e)
        {
            ActiveRentalsUserControl.Visibility = Visibility.Visible;
            RentalsHistoryUserControl.Visibility = Visibility.Hidden;
            AccountInfoUserControl.Visibility = Visibility.Hidden;
            
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            ActiveRentalsUserControl.Visibility = Visibility.Hidden;
            RentalsHistoryUserControl.Visibility = Visibility.Visible;
            AccountInfoUserControl.Visibility = Visibility.Hidden;
        }

        private void AccountInfo_Click(object sender, RoutedEventArgs e)
        {
            ActiveRentalsUserControl.Visibility = Visibility.Hidden;
            RentalsHistoryUserControl.Visibility = Visibility.Hidden;
            AccountInfoUserControl.Visibility = Visibility.Visible;
        }

        private void NoobFilter_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 50; i++)
            {
                MessageBox.Show("Björn e n00b", "hehe", 
                    MessageBoxButton.OKCancel, 
                    MessageBoxImage.Error, 
                    MessageBoxResult.None, 
                    MessageBoxOptions.RtlReading);
            }
        }
    }
}

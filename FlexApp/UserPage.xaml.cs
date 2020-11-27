using System;
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

namespace FlexApp
{
    public partial class UserPage : UserControl
    {
        public UserPage()
        {
            InitializeComponent();

            AvatarImage.Source = new BitmapImage(new Uri(Helper.Image.BjornAvatarURL));

        }

        private void ActiveRentals_Click(object sender, RoutedEventArgs e)
        {
            ActiveRentalsUserControl.Visibility = Visibility.Hidden;
            RentalsHistoryUserControl.Visibility = Visibility.Visible;
            AccountInfoUserControl.Visibility = Visibility.Hidden;
            
        }

        private void History_Click(object sender, RoutedEventArgs e)
        {
            ActiveRentalsUserControl.Visibility = Visibility.Visible;
            RentalsHistoryUserControl.Visibility = Visibility.Hidden;
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

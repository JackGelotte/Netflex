using System;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DatabaseConnection;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for UserPageRentalsHistory.xaml
    /// </summary>
    public partial class UserPageRentalsHistory : UserControl
    {

        public ObservableCollection<MovieHistory> RentalHistoryListView { get; set; } = new ObservableCollection<MovieHistory>();

        public string SelectedRental { get; set; }

        public class MovieHistory
        {
            public string Title { get; set; }

            public string Date { get; set; }

            
            public MovieHistory(string title, string date) { Title = title; Date = date; }

            public override string ToString()
            {
                return $"Movie : {Title}  |  Date : {Date}";
            }

        }


        public UserPageRentalsHistory()
        {
            InitializeComponent();

            DataContext = this;

            movieHistoryDataBinding.ItemsSource = RentalHistoryListView;
        }
    }
}

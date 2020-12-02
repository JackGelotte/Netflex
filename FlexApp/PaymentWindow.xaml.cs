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
using System.Windows.Shapes;
using DatabaseConnection;
using System.IO;
using Microsoft.Win32;
using System.Linq;
using System.Collections.ObjectModel;

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private bool isPayed = false;
        public bool IsPayed { get { return isPayed; } set { isPayed = value; } }

        public Movie MovieSelected { get; set; }
        public int DaysActiveSelected { get; set; }

        public class ComboBoxMonth
        {
            public string Month { get; set; }
            public ComboBoxMonth(string month)
            {
                Month = month;
            }
        }
        public class ComboBoxYear
        {
            public string Year { get; set; }
            public ComboBoxYear(string year)
            {
                Year = year;
            }
        }

        public ObservableCollection<ComboBoxMonth> ComboMonth
        {
            get
            {
                return new ObservableCollection<ComboBoxMonth>()
                { new ComboBoxMonth("01"), new ComboBoxMonth("02"),
                new ComboBoxMonth("03"), new ComboBoxMonth("04"),
                new ComboBoxMonth("05"), new ComboBoxMonth("06"),
                new ComboBoxMonth("07"), new ComboBoxMonth("08"),
                new ComboBoxMonth("09"), new ComboBoxMonth("10"),
                new ComboBoxMonth("11"), new ComboBoxMonth("12"),};
            }
        }
        public ObservableCollection<ComboBoxYear> ComboYear { get
            {
                return new ObservableCollection<ComboBoxYear>() {
                new ComboBoxYear("2020"),  new ComboBoxYear("2021"), new ComboBoxYear("2022"), new ComboBoxYear("2023"), new ComboBoxYear("2024")
                };}
            }

        public PaymentWindow(Movie movie, int daysActive)
        {
            InitializeComponent();
            MovieSelected = movie;
            DaysActiveSelected = daysActive;
            DataContext = this;
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            if(PhotoId.Source == null)
            {
                MessageBox.Show(Helper.Message.PaymentNoID);
                return;
            }
            if (CardNo.Text.Length < 15 || CardNo.Text.Length > 18 || CardNo.Text.Any(x => !Char.IsDigit(x)))
            {
                MessageBox.Show(Helper.Message.PaymentIncorrectCardNo);
                Name.Text = string.Empty;
                CardNo.Text = string.Empty;
                csv.Text = string.Empty;
                expMonth.Text = string.Empty;
                expYear.Text = string.Empty;
                return;
            }
            if (csv.Text.Length != 3 || csv.Text.Any(x => !Char.IsDigit(x)))
            {
                MessageBox.Show(Helper.Message.PaymentIncorrectCSV);
                Name.Text = string.Empty;
                CardNo.Text = string.Empty;
                csv.Text = string.Empty;
                expMonth.Text = string.Empty;
                expYear.Text = string.Empty;
                return;
            }
            if(string.IsNullOrEmpty(expYear.Text) || string.IsNullOrEmpty(expMonth.Text))
            {
                MessageBox.Show(Helper.Message.PaymentReqExp);
                Name.Text = string.Empty;
                CardNo.Text = string.Empty;
                csv.Text = string.Empty;
                expMonth.Text = string.Empty;
                expYear.Text = string.Empty;
                return;
            }
            
            try
            {
                new User.Rental(MovieSelected).Execute(DaysActiveSelected);
                UserPage.UserPageUserControl.Refresh();
                MessageBox.Show("Rental osv");
            }
            catch (Exception er)
            {
                MessageBox.Show("du suger osv, jupp" + er);
            }

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BrowsePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog oF = new OpenFileDialog();

            oF.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            oF.DefaultExt = ".jpg";
            oF.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*jpg|All files (*.*)|*.*";

            if (oF.ShowDialog() == true)
            {
                PhotoId.Source = new BitmapImage(new Uri(oF.FileName));
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

    }
}

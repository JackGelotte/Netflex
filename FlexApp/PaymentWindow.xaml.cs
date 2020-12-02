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

namespace FlexApp
{
    /// <summary>
    /// Interaction logic for PaymentWindow.xaml
    /// </summary>
    public partial class PaymentWindow : Window
    {
        private bool isPayed = false;
        public bool IsPayed { get { return isPayed; } set { isPayed = value; } }
        public PaymentWindow()
        {
            InitializeComponent();
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BrowsePhoto_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

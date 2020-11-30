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
    /// <summary>
    /// Interaction logic for NextPrevious.xaml
    /// </summary>
    public partial class NextPrevious : UserControl
    {
        public NextPrevious()
        {
            InitializeComponent();
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            MovieDisplay.MovieDisplayUserControl.Click_Next(sender, e);
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            MovieDisplay.MovieDisplayUserControl.Click_Previous(sender, e);
        }
    }
}

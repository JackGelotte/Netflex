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
    /// Interaction logic for ButtonMenu.xaml
    /// </summary>
    public partial class ButtonMenu : UserControl
    {
        public const int BUTTON_SEPARATOR = 150;
        public ButtonMenu()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Categories_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hot_Click(object sender, RoutedEventArgs e)
        {
            MovieViewer.LoadPopularMovies();
        }
    }
}

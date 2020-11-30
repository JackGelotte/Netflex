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
    /// Interaction logic for AboutAlt.xaml
    /// </summary>
    public partial class AboutAlt : UserControl
    {
        public AboutAlt()
        {
            InitializeComponent();

            Arnold.Source = new BitmapImage(new Uri(@"C:\Users\robin\Desktop\Arnold2.png"));
        }
    }
}

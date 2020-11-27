using System;
using System.Collections.Generic;
using System.Reflection;
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
    /// Interaction logic for WatchMovieWindow.xaml
    /// </summary>
    public partial class WatchMovieWindow : Window
    {
        public WatchMovieWindow()
        {
            InitializeComponent();
        }

        public void HideScriptErrors(WebBrowser wb, bool Hide)
        {
            FieldInfo fi = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);

            if (fi == null) return;

            object o = fi.GetValue(wb);

            if (o == null) return;

            o.GetType().InvokeMember("Silent", BindingFlags.SetProperty, null, o, new object[] { Hide });
        }

        public void Browser_Navigated(object sender, NavigationEventArgs e)
        {
            HideScriptErrors(this.Browser, true);
        }
    }
}

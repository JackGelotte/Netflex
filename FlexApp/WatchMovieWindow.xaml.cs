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
            FieldInfo fiComWebBrowser = typeof(WebBrowser).GetField("_axIWebBrowser2", BindingFlags.Instance | BindingFlags.NonPublic);

            if (fiComWebBrowser == null) return;

            object objComWebBrowser = fiComWebBrowser.GetValue(wb);

            if (objComWebBrowser == null) return;

            objComWebBrowser.GetType().InvokeMember(

            "Silent", BindingFlags.SetProperty, null, objComWebBrowser, new object[] { Hide });

        }

        public void Browser_Navigated(object sender, NavigationEventArgs e)
        {

            HideScriptErrors(this.Browser, true);

        }
    }
}

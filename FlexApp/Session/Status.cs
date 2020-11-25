using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;

namespace FlexApp
{

    public static class Status
    {
        public static bool IsLoggedIn { get; set; }

        public static Customer Customer { get; set; }


        public static Context ct = new Context();

        public static void ShowHistory() 
        { 

        }

        public static void LogOut() { Customer = null; IsLoggedIn = false; }

    }
}

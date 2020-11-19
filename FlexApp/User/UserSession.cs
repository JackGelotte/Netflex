using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;

namespace FlexApp
{

    class UserSession
    {
        public bool IsLoggedIn { get; set; }

        public Customer Customer { get; set; }

        public UserSession() { IsLoggedIn = false; }


        public void ShowHistory() { }




    }
}

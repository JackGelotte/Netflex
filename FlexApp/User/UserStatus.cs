using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;

namespace FlexApp
{

    class UserStatus
    {
        public bool IsLoggedIn { get; set; }

        public Customer Customer { get; set; }

        public UserStatus() { IsLoggedIn = false; }


        public void ShowHistory() { }




    }
}

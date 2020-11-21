using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;

namespace FlexApp.User
{
    public class UserRental
    {
        public UserSession User { get; set; }

        public Movie Movie { get; set; }

        public UserRental(UserSession user)
        {
            User = user;
        }

        public void RegisterRental(Movie movie)
        {
            if(!User.IsLoggedIn)
            {
                UserCreation.CreateNewUser(User);
            }
            if(User.IsLoggedIn)
            {

            }
        }


    }
}

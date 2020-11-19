using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;


namespace FlexApp.User
{
    class AppRental
    {
        public UserSession User { get; set; }

        public Movie Movie { get; set; }

        public bool isPayed { get; set; }

        public AppRental(UserSession user) 
        {
            User = user;
            isPayed = false;
        }

        public void RegisterRental(Movie movie, int daysActive)
        {
            if(!User.IsLoggedIn)
            {
                UserCreation.CreateNewUser(User);
            }

            this.Payment(daysActive);

            if(User.IsLoggedIn && isPayed)
            {
                using(Context ct = new Context())
                {
                    Rental r = new Rental()
                    {
                        RentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        ReturnDate = DateTime.Now.AddDays(daysActive).ToString("yyyy-MM-dd"),
                        Customer = User.Customer,
                        Movie = this.Movie
                    };
                }               
            }
        }

        public void Payment(int daysActive)
        {

            if(true)// Payment stuff
            {
                this.isPayed = true;
            }

        }

    }
}

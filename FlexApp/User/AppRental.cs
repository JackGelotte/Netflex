using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;


namespace FlexApp.User
{
    public class AppRental
    {
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }

        public bool isPayed { get; set; }

        public AppRental() 
        {
            try { Customer = UserSession.Customer; }
            catch { }
            isPayed = false;
        }

        public void RegisterRental(Movie movie, int daysActive)
        {
            Payment(daysActive);

            if(UserSession.IsLoggedIn && isPayed)
            {
                using(Context ct = new Context())
                {
                    Rental r = new Rental()
                    {
                        RentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                        ReturnDate = DateTime.Now.AddDays(daysActive).ToString("yyyy-MM-dd"),
                        Customer = this.Customer,
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

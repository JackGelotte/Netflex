using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;


namespace FlexApp.User
{
    public static class AppRental
    {
        public static bool isPayed { get; set; }

        public static void RegisterRental(Customer customer, Movie movie, int daysActive)
        {
            Payment(daysActive);

            if(UserSession.IsLoggedIn && isPayed)
            {
                UserSession.ct.Rentals.Add(new Rental()
                {
                    RentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    ReturnDate = DateTime.Now.AddDays(daysActive).ToString("yyyy-MM-dd"),
                    Customer = customer,
                    Movie = movie
                });
                UserSession.ct.SaveChanges();
            }
        }

        public static void Payment(int daysActive)
        {
            if(true)
            {
                isPayed = true;
            }
        }

    }
}

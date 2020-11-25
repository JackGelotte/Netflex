using System;
using System.Collections.Generic;
using System.Text;
using DatabaseConnection;


namespace FlexApp.User
{
    public static class Rental
    {
        public static bool isPayed { get; set; }

        public static void Execute(Movie movie, int daysActive)
        {
            Payment(daysActive);

            if(Status.IsLoggedIn && isPayed)
            {
                Status.ct.Add(new DatabaseConnection.Rental()
                {
                    RentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    ReturnDate = DateTime.Now.AddDays(daysActive).ToString("yyyy-MM-dd"),
                    Customer = Status.Customer,
                    Movie = movie
                });
                Status.ct.SaveChanges();
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DatabaseConnection;


namespace FlexApp.User
{
    public class Rental
    {
        public bool IsPayed { get; set; }

        public Customer Customer { get; set; }

        public Movie Movie { get; set; }

        public static ObservableCollection<Rental> RentalsInProcess = new ObservableCollection<Rental>();

        public Rental(Movie movie) 
        { 
            Customer = Status.Customer;
            IsPayed = false;
            Movie = movie;
            RentalsInProcess.Add(this);
        }

        public void Execute(int daysActive)
        {
            Payment(daysActive);

            if(Status.IsLoggedIn && IsPayed)
            {
                Status.ct.Add(new DatabaseConnection.Rental()
                {
                    RentDate = DateTime.Now.ToString("yyyy-MM-dd"),
                    ReturnDate = DateTime.Now.AddDays(daysActive).ToString("yyyy-MM-dd"),
                    Customer = Status.Customer,
                    Movie = Movie
                });
                Status.ct.SaveChanges();
            }
        }

        public void Payment(int daysActive)
        {
            if(true)
            {
                IsPayed = true;
            }
        }

    }
}

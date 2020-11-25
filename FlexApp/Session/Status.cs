using System;
using System.Linq;
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

        public static IEnumerable<User.Rental> ShowInProcess() => User.Rental.RentalsInProcess.Where(r => r.Customer.Equals(Customer) && r.IsPayed.Equals(false));

        public static IEnumerable<Rental> ShowHistory() => Status.ct.Rentals.Where(r => r.Customer.Equals(Customer));

        public static void LogOut() { Customer = null; IsLoggedIn = false; }

    }
}

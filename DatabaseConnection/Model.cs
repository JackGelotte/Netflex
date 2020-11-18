 using System;
using System.Collections.Generic;

namespace DatabaseConnection
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        // References to other tables
        public virtual UserPassword UserPassword { get; set; }
        public virtual ICollection<Rental> Rentals { get; set; }
    }
    public class UserPassword
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public  virtual UserAccount UserAccount { get; set; }
    }
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        // References to other tables
        public virtual ICollection<Rental> Rentals { get; set; }
    }
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        // References to other tables
        public virtual UserAccount UserAccount { get; set; }
        public virtual Movie Movie { get; set; }
    }
}

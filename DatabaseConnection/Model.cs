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
        // public string AvatarUrl { get; set; }
        // References to other tables
        public virtual Login Login { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }

    public class Login
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        // References to other tables

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }

    public class Movie
    {
        public int Id { get; set; }
        public int ImdbID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Rating { get; set; }
        public string PosterLink { get; set; }
       // public string TrailerLink { get; set; }
       // public string Synopsis { get; set; }

        // References to other tables
        public virtual ICollection<Rental> Rentals { get; set; }
    }

    public class Rental
    {
        public int Id { get; set; }
        public string RentDate { get; set; }
        public string ReturnDate { get; set; }

        // References to other tables
        public virtual Customer Customer { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
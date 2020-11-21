using System.Collections.Generic;

namespace DatabaseConnection
{
    public enum Genre
    {
        Action,
        Adventure,
        Animation,
        Biography,
        Comedy,
        Crime,
        Documentary,
        Drama,
        Family,
        Fantasy,
        FilmNoir,
        History,
        Horror,
        Music,
        Musical,
        Mystery,
        Romance,
        SciFi,
        Short,
        Sport,
        Superhero,
        Thriller,
        War,
        Western,
        Other
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }

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
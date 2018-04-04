using System;
using System.Collections.Generic;

namespace Webapp.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReturnDate { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        public int RentMovieId { get; set; }
        public Movie RentMovie { get; set; }

    }
}
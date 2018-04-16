using System;
using System.Collections.Generic;

namespace Webapp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public decimal TotalAmount  { get; set; }
        public DateTime PaymentDate { get; set; }

        public List<Rental> Rentals { get; set; }

    }
}
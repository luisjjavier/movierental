using System;
using System.Collections.Generic;

namespace Webapp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; }

        public ISet<Payment> Payments { get; set; }
    }
}
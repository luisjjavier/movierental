using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webapp.Models
{
    public class WaitList
    {
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
    }
}
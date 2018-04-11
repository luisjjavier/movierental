using System;
using System.Collections.Generic;

namespace Webapp.Models
{
    public sealed class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string NickName { get; set; }
        public DateTime Created { get; set; }

        public ICollection<Movie> Movies { get; set; }
    }
}
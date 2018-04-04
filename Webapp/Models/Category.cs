using System.Collections.Generic;

namespace Webapp.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ISet<Movie> Movies { get; set; }
    }
}
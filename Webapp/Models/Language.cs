using System.Collections.Generic;

namespace Webapp.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ISet<Movie> Movies { get; set; }
        public virtual ISet<Movie> OriginalLanguageMovies { get; set; }
    }
}
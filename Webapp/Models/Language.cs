using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class Language
    {
        public int Id { get; set; }
        [DisplayName("Idioma")]
        public string Name { get; set; }

        public virtual ISet<Movie> Movies { get; set; }
        public virtual ISet<Movie> OriginalLanguageMovies { get; set; }
    }
}
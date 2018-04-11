using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class MovieViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Es necesario el titulo")]
        [DisplayName("Titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Es necesario la imagen")]
        [DisplayName("Imagen")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Es necesario la Image")]
        [DisplayName("Breve descrición")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La fecha de publicacion es requerida")]
        [DisplayName("Año de publicacion")]
        [Range(minimum:1800, maximum:2400,ErrorMessage = "El año no es valido, tiene que star entre 1800 y 2400")]
        public int ReleaseYear { get; set; }


        [Required(ErrorMessage = "El director es requerido")]
        [DisplayName("Director")]
        public string Director { get; set; }

        [Required(ErrorMessage = "El Lenguaje es requerido")]
        [DisplayName("Lenguaje")]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "El Lenguaje es requerido")]
        [DisplayName("Lenguaje original")]
        public int OriginalLanguageId { get; set; }

        [Required(ErrorMessage = "La calificacion de la pelicula es requerida")]
        [DisplayName("calificacion")]
        [Range(minimum: 1, maximum: 5, ErrorMessage = "La calificaion no es valida. tiene que ser entre 1 y 5")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "El costo del replazo es requerido")]
        [DisplayName("Costo de remplazo")]
        public decimal ReplacementCost { get; set; }

        [Required(ErrorMessage = "El precio de alquiler es requerido")]
        [DisplayName("Costo de remplazo")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El usuario creador es requerido")]
        public string ApplicationUserId { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public class ActorViewModel
    {
        public int Id { get; set; }
        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre del actor es requerido")]
        public string Name { get; set; }

        [DisplayName("Foto")]
        [Required(ErrorMessage = "La foto del actor es requerida")]
        public string ImageUrl { get; set; }

        [DisplayName("Apodo")]
        public string NickName { get; set; }
    }
}
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Webapp.Models
{
    public sealed class CustomerViewModel
    {
        [DisplayName("Codigo")]
        public int Id { get; set; }

        [Required(ErrorMessage = "El primer nombre es requerido")]
        [DisplayName("Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Los apellidos del cliente son requeridos")]
        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "El email puesto no es valido")]
        [DisplayName("Correo electronico")]
        [Required(ErrorMessage = "El correo electronico es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Se necesita su dirección")]
        [DisplayName("Dirección")]
        public string Address { get; set; }

        [Phone(ErrorMessage = "El número de telefono no es valido")]
        [DisplayName("Teléfono")]
        [Required(ErrorMessage = "El número de telefono es requerido")]
        public string Phone { get; set; }
    }
}
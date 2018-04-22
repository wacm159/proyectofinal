using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace test.Models
{    
       
     public class BodeMetadata
    {
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 5 y 10 caracteres")]
        [Remote("ValidarNombre","Bodegas", ErrorMessage="Campo Duplicado")]
        public string Nombre { get; set; }
    }

    public class ProductoMetadata
    {
        [Required]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 5 y 10 caracteres")]
        [Remote("ValidarNombreP", "Productoes", ErrorMessage = "Campo Duplicado")]
        public string Nombre { get; set; }
    }

    public class ContactosMetadata
    {
        [Required]
        [Display(Name = "Nombre Usuario")]
        public string nombre { get; set; }

        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "La direccion de correo es requerida")]
        [EmailAddress(ErrorMessage = "Direccion de correo Invalida")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public string telefono { get; set; }

        [Required]
        [Display(Name = "Mensaje")]
        public string mensaje { get; set; }
    }
}
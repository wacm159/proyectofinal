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
}
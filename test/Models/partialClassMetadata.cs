using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace test.Models
{
    [MetadataType(typeof(BodeMetadata))]
    public partial class Bodega
    {
    }

    [MetadataType(typeof(ProductoMetadata))]
    public partial class Producto
    {
    }
}
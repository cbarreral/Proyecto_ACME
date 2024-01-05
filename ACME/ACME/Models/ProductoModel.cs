using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Define las entidades del dominio que reflejan la lógica y las reglas del negocio.
namespace ACME.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoBarras { get; set; }
        public decimal Precio { get; set; }
    }
}

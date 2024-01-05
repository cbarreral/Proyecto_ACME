using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Define las entidades del dominio que reflejan la lógica y las reglas del negocio.
namespace ACME.Models
{
    public class InventarioModel
    {
        public int Id { get; set; }
        public int SucursalId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadTotalDeProductosDisponibles { get; set; }
        public DateTime FechaActualizacion { get; set; }

        // Relaciones
        public SucursalModel Sucursal { get; set; }
        public ProductoModel Producto { get; set; }
    }
}

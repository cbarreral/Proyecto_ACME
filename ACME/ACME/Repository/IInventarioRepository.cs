using ACME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Repository
{
    //Abstrae el acceso a los datos, permitiendo que puedas cambiar fácilmente la fuente de datos o la tecnología de acceso a datos sin afectar al resto del sistema
    public interface IInventarioRepository
    {
        Task<IEnumerable<Inventario_Model>> GetInventarioPorSucursalAsync(int sucursalId);
    }
     
    public class InventarioRepository : IInventarioRepository
    {
        public async Task<IEnumerable<Inventario_Model>> GetInventarioPorSucursalAsync(int sucursalId)
        {
            // Aquí iría la lógica para consultar la base de datos y obtener el inventario
            return new List<Inventario_Model>(); // Retornar resultados
        }
    }
}

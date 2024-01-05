using ACME.Controllers;
using ACME.Data;
using ACME.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ACME.Repository
{
    //Abstrae el acceso a los datos, permitiendo que puedas cambiar fácilmente la fuente de datos o la tecnología de acceso a datos sin afectar al resto del sistema
    public interface IInventarioRepository
    {
        Task<IEnumerable<InventarioModel>> GetInventarioPorSucursalAsync(int sucursalId);
        Task AgregarInventarioAsync(InventarioModel sucursalId);
        Task<InventarioModel> ObtenerInventarioPorIdAsync(int sucursalId);
        Task ActualizarInventarioAsync(int id,InventarioModel sucursalId);
        Task EliminarInventarioAsync(int sucursalId);
    }

    public class InventarioRepository : IInventarioRepository
    {
        private readonly AcmeContext _context;

        public InventarioRepository(AcmeContext context)
        {
            _context = context;
        }

        public async Task  ActualizarInventarioAsync(int id,InventarioModel inventario)
        {

            // Lógica para ejecutar el procedimiento almacenado
            var id_inventarioParam = new SqlParameter("@id_inventario", id);
            var cantidadParam = new SqlParameter("@cantidad", inventario.CantidadTotalDeProductosDisponibles);

            await _context.Database.ExecuteSqlRawAsync("EXEC sp_acme_actualizar_inventario @id_inventario, @cantidad",
                                                         id_inventarioParam, cantidadParam);
        }

        public async Task AgregarInventarioAsync(InventarioModel inventario)
        {
            // Lógica para ejecutar el procedimiento almacenado
            var productoIdParam = new SqlParameter("@ProductoId", inventario.ProductoId);
            var sucursalIdParam = new SqlParameter("@SucursalId", inventario.SucursalId);
            var cantidadParam = new SqlParameter("@Cantidad", inventario.CantidadTotalDeProductosDisponibles);
            var fechaActualizacionParam = new SqlParameter("@FechaActualizacion", inventario.FechaActualizacion);

            await _context.Database.ExecuteSqlRawAsync("EXEC spAddInventario @ProductoId, @SucursalId, @Cantidad, @FechaActualizacion",
                                                       productoIdParam, sucursalIdParam, cantidadParam, fechaActualizacionParam);
        }

        public async Task EliminarInventarioAsync(int id)
        {
            // Lógica para ejecutar el procedimiento almacenado
            var id_inventarioParam = new SqlParameter("@id_inventario", id);
            
            await _context.Database.ExecuteSqlRawAsync("EXEC sp_acme_eliminar_inventario @id_inventario",
                                                       id_inventarioParam);
        }

        public async Task<IEnumerable<InventarioModel>> GetInventarioPorSucursalAsync(int sucursalId)
        {
            // Lógica para ejecutar el procedimiento almacenado
            var inventario = await _context.Inventarios
                                           .FromSqlRaw("EXEC spGetInventarioPorSucursal @SucursalId",
                                                       new SqlParameter("@SucursalId", sucursalId))
                                           .ToListAsync(); 
            return inventario;
        }
 

        public async Task<InventarioModel> ObtenerInventarioPorIdAsync(int id)
        {
              var idParam =  new SqlParameter("@id_inventario", id);
             
            var inventario = await _context.Inventarios
                                           .FromSqlRaw("EXEC sp_acme_obtener_inventario_por_id @id_inventario", idParam)
                                           .FirstOrDefaultAsync();

            return inventario;
        }
    }
}

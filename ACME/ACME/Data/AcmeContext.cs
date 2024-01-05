using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ACME.Models;

namespace ACME.Data
{

    public class AcmeContext : DbContext
    {
        public AcmeContext(DbContextOptions<AcmeContext> options)
            : base(options)
        {
        }

        public DbSet<Sucursal_Model> Sucursales { get; set; }
        public DbSet<Producto_Model> Productos { get; set; }
        public DbSet<Inventario_Model> Inventarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuraciones adicionales
        }
    }

}

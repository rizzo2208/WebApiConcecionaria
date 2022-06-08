using API.Core.Business.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Core.Business.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Venta>? Ventas { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Vehiculo>? Vehiculos { get; set; }
        public DbSet<Usuario>? Usuarios { get; set; }
        
    }
}

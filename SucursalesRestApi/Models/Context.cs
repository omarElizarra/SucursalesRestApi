using Microsoft.EntityFrameworkCore;

namespace SucursalesRestApi.Models
{
    public class Context : DbContext
    {
      
            public Context(DbContextOptions<Context> options) : base(options)
            {
                
            }
            public DbSet<Sucursales> Sucursales { get; set; }

            public DbSet<Empleados> Empleados { get; set;}
        
    }
}

using Microsoft.EntityFrameworkCore;
using PruebasPOC.Models;

namespace PruebasPOC.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Ingreso> Ingresos { get; set; } 

    }
}

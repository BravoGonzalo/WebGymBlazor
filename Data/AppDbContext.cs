using Microsoft.EntityFrameworkCore;
using ProyectoGym.Domain; 

namespace ProyectoGym.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }
    }
}

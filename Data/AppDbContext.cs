using Microsoft.EntityFrameworkCore;
using ProyectoGym.Domain; 

namespace ProyectoGym.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Entrenador> Entrenadores { get; set; } = null!;
        public DbSet<Rutina> Rutinas { get; set; } = null!;
        
    }
}

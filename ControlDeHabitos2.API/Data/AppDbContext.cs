using ControlDeHabitos2.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlDeHabitos2.API.Data
{

        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Habito> Habitos { get; set; }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                // Relación uno a muchos: Usuario → Habitos
                modelBuilder.Entity<Usuario>()
                    .HasMany(u => u.Habitos)
                    .WithOne(h => h.Usuario)
                    .HasForeignKey(h => h.UsuarioId);

                modelBuilder.Entity<Usuario>()
                    .HasIndex(u => u.Nombre)
                    .IsUnique(); // Nombre único por usuario
            }
        }
}



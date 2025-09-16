using Microsoft.EntityFrameworkCore;
using Sprint1.Entities;

namespace Sprint1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Modelo>()
                .HasMany(m => m.Motos)
                .WithOne(mo => mo.Modelo)
                .HasForeignKey(mo => mo.ModeloId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Patio>()
                .HasMany(p => p.Motos)
                .WithOne(mo => mo.Patio)
                .HasForeignKey(mo => mo.PatioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Moto>()
                .HasIndex(m => m.Placa)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}

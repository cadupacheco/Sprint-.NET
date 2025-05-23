using Microsoft.EntityFrameworkCore;
using API_NET.Models;

namespace API_NET.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Moto> Motos { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Patio> Patios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("API_NET");
            base.OnModelCreating(modelBuilder);
        }
    }
}
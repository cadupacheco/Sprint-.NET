using Microsoft.EntityFrameworkCore;
using Sprint1.Entities;

namespace Sprint1.Data
{
    public static class SeedData
    {
        public static void Initialize(AppDbContext context)
        {
            // Garantir que o banco foi criado
            context.Database.EnsureCreated();
            
            // Limpar modelos existentes apenas se necessário
            if (context.Modelos.Any())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM Modelos");
                context.SaveChanges();
            }
            
            // Adicionar novos modelos de motos elétricas
            if (!context.Modelos.Any())
            {
                context.Modelos.AddRange(
                    new Modelo { Nome = "VMoto VS1", Fabricante = "VMoto" },
                    new Modelo { Nome = "Super Soco CPX", Fabricante = "Super Soco" },
                    new Modelo { Nome = "VMoto Super Soco TSX", Fabricante = "VMoto" }
                );
                context.SaveChanges();
            }
            
            // Garantir que há pelo menos um pátio
            if (!context.Patios.Any())
            {
                context.Patios.AddRange(
                    new Patio { Nome = "Pátio Centro", Localizacao = "Rua das Flores, 123 - Centro" },
                    new Patio { Nome = "Pátio Norte", Localizacao = "Av. Paulista, 456 - Bela Vista" }
                );
                context.SaveChanges();
            }
        }
    }
}
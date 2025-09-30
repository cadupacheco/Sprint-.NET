using Swashbuckle.AspNetCore.Filters;
using Sprint1.Dtos;

namespace Sprint1.Examples
{
    public class MotoCreateDtoExample : IExamplesProvider<MotoCreateDto>
    {
        public MotoCreateDto GetExamples()
        {
            return new MotoCreateDto
            {
                Placa = "ABC-1234",
                Cor = "Vermelha",
                Status = "available",
                LocationX = -23.5505,
                LocationY = -46.6333,
                BatteryLevel = 85,
                FuelLevel = 90,
                Mileage = 15000,
                NextMaintenanceDate = "2025-03-15T10:00:00Z",
                AssignedBranch = "São Paulo Centro",
                TechnicalInfo = "Bateria: 85%, Última manutenção: 15/01/2025",
                ModeloId = 1,
                PatioId = 1
            };
        }
    }
}

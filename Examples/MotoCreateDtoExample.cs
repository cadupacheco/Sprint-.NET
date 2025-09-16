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
                ModeloId = 1,
                PatioId = 1
            };
        }
    }
}

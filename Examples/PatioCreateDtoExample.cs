using Swashbuckle.AspNetCore.Filters;
using Sprint1.Dtos;

namespace Sprint1.Examples
{
    public class PatioCreateDtoExample : IExamplesProvider<PatioCreateDto>
    {
        public PatioCreateDto GetExamples()
        {
            return new PatioCreateDto
            {
                Nome = "Pátio Centro",
                Localizacao = "Rua A, 123"
            };
        }
    }
}

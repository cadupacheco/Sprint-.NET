using Swashbuckle.AspNetCore.Filters;
using Sprint1.Dtos;

namespace Sprint1.Examples
{
    public class ModeloCreateDtoExample : IExamplesProvider<ModeloCreateDto>
    {
        public ModeloCreateDto GetExamples()
        {
            return new ModeloCreateDto
            {
                Nome = "CB 500",
                Fabricante = "Honda"
            };
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace Sprint1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Verifica se a API está funcionando
        /// </summary>
        /// <returns>Status da API</returns>
        /// <response code="200">API está funcionando</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            return Ok(new { 
                status = "API funcionando!", 
                timestamp = DateTime.UtcNow,
                version = "1.0.0",
                environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
            });
        }
    }
}
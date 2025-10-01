using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Sprint1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public HealthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

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

        /// <summary>
        /// Testa a conexão com o banco Oracle
        /// </summary>
        /// <returns>Status da conexão Oracle</returns>
        [HttpGet("oracle")]
        public async Task<IActionResult> TestOracleConnection()
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("OracleConnection");
                using var connection = new OracleConnection(connectionString);
                
                await connection.OpenAsync();
                
                using var command = new OracleCommand("SELECT 'Oracle OK' FROM DUAL", connection);
                var result = await command.ExecuteScalarAsync();

                return Ok(new
                {
                    status = "✅ Oracle Connection SUCCESS!",
                    database = connection.DatabaseName,
                    serverVersion = connection.ServerVersion,
                    connectionState = connection.State.ToString(),
                    testResult = result,
                    timestamp = DateTime.UtcNow
                });
            }
            catch (OracleException ex)
            {
                return StatusCode(500, new
                {
                    status = "❌ Oracle Connection FAILED",
                    error = ex.Message,
                    errorCode = ex.Number,
                    suggestion = ex.Number switch
                    {
                        12514 => "Serviço Oracle não encontrado",
                        1017 => "Usuário ou senha incorretos",
                        50201 => "Falha na comunicação",
                        _ => "Erro desconhecido"
                    },
                    timestamp = DateTime.UtcNow
                });
            }
        }
    }
}
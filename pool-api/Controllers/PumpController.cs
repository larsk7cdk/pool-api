using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pool_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PumpController : ControllerBase
    {
        private readonly ILogger<PumpController> _logger;

        public PumpController(ILogger<PumpController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("run")]
        public async Task<IActionResult> Run([FromQuery] string run)
        {
            _logger.LogInformation($"Pump run value: {run}");
            return Ok($"Pump status is: {run}{Environment.NewLine}");
        }
    }
}
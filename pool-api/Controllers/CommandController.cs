using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace pool_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ILogger<CommandController> _logger;

        public CommandController(ILogger<CommandController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("pump")]
        public async Task<IActionResult> Pump([FromQuery] string pumpRun)
        {
            _logger.LogInformation($"Pump run value: {pumpRun}");
            return Ok($"{pumpRun}{Environment.NewLine}");
        }
    }
}
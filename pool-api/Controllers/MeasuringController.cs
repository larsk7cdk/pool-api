using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pool_api.DomainServices;
using pool_api.Models;

namespace pool_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuringController : ControllerBase
    {
        private readonly ILogger<MeasuringController> _logger;

        public MeasuringController(ILogger<MeasuringController> logger)
        {
            _logger = logger;
        }

        //[HttpGet]
        //[Route("update")]
        //public async Task<IActionResult> Update(
        //    [FromServices] IMeasureService measureService,
        //    [FromQuery] string temp,
        //    [FromQuery] string ph,
        //    [FromQuery] string timestamp) => await measureService.Create(temp, ph, timestamp);

        [HttpGet]
        [Route("console")]
        public IActionResult GetConsole(
            [FromQuery] string s)
        {
            _logger.LogInformation(s);
            return Ok();
        }

        [HttpPost]
        [Route("console")]
        public IActionResult PostConsole([FromBody] StringRequest s)
        {
            _logger.LogInformation(s.S);
            return Ok();
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(
            [FromServices] IMeasureService measureService,
            [FromBody] MeasureRequest[] measurings) => await measureService.Create(measurings);

        //_logger.LogInformation($"Measure value temp is: {temp} and ph is: {ph}");
        //return Ok($"Measuring OK {Environment.NewLine}");
    }
}
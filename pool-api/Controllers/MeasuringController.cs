using System;
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

        [HttpGet]
        [Route("epoch")]
        public IActionResult Epoch(
            [FromQuery] string s)
        {
            ulong e = Convert.ToUInt64(s);

            var dto = new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero);
            var dateTimeOffset = dto.AddSeconds(e);


            _logger.LogInformation(dateTimeOffset.ToString());
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
        [Route("create")]
        public async Task<IActionResult> Create(
            [FromServices] IMeasureService measureService,
            [FromBody] MeasureRequest measuring) => await measureService.Create(measuring);
        
        
        //[HttpPost]
        //[Route("create")]
        //public async Task<IActionResult> Create(
        //   [FromServices] IMeasureService measureService,
        //   [FromBody] MeasureRequest[] measurings) => await measureService.Create(measurings);

    }
}
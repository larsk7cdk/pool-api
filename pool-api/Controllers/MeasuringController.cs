using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pool_api.DomainServices;
using pool_api.Models;

namespace pool_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuringController : ControllerBase
    {
        //[HttpGet]
        //[Route("update")]
        //public async Task<IActionResult> Update(
        //    [FromServices] IMeasureService measureService,
        //    [FromQuery] string temp,
        //    [FromQuery] string ph,
        //    [FromQuery] string timestamp) => await measureService.Create(temp, ph, timestamp);

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(
            [FromServices] IMeasureService measureService,
            [FromBody] MeasureRequest[] measurings) => await measureService.Create(measurings);

        //_logger.LogInformation($"Measure value temp is: {temp} and ph is: {ph}");
        //return Ok($"Measuring OK {Environment.NewLine}");
    }
}
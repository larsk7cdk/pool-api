using Microsoft.AspNetCore.Mvc;
using pool_api.DomainServices;
using System.Threading.Tasks;

namespace pool_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasuringController : ControllerBase
    {
        [HttpGet]
        [Route("update")]
        public async Task<IActionResult> Update(
            [FromServices] IMeasuringService measuringService,
            [FromQuery] string temp,
            [FromQuery] string ph) =>
             await measuringService.Log(temp, ph);



        //_logger.LogInformation($"Measure value temp is: {temp} and ph is: {ph}");
        //return Ok($"Measuring OK {Environment.NewLine}");
    }
}
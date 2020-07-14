//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace pool_api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class MortageController : ControllerBase
//    {
//        [HttpPost]
//        [Route("modificationcalculation")]
//        public async Task<IActionResult> MortageModificationCalculation(
//            [FromServices] IMortageFacade mortageFacade,
//            [FromBody] ModificationRequest request)
//        {
//            var response = await mortageFacade.MortageModificationCalculation(request);

//            return Ok(response);
//        }
//    }
//}
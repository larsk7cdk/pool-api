//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;

//namespace pool_api.Controllers
//{
//    [Route("api/applab/[controller]")]
//    [ApiController]
//    public class CustomerController : ControllerBase
//    {
//        [HttpGet]
//        [Route("customeridentification")]
//        public async Task<IActionResult> CustomerIdentification([FromServices] ICustomerFacade customerFacade)
//        {
//            var response = await customerFacade.CustomerIndentification();

//            return Ok(response);
//        }

//        [HttpGet]
//        [Route("customercommitment")]
//        public async Task<IActionResult> CustomerCommitment([FromServices] ICustomerFacade customerFacade)
//        {
//            var response = await customerFacade.CustomerCommitment();

//            return Ok(response);
//        }
//    }
//}
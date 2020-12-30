using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Backend.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("policy1")]
    public class SalesController : ControllerBase
    {
        public SalesController()
        {
        }

        [HttpGet("getallsales")]
        public async Task<OkObjectResult> GetSalesDataRange()
        { 
            return Ok("Sale");
        }
    }
}
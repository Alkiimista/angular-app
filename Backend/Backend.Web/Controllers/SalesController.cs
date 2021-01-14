using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Backend.Services;

namespace Backend.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("policy1")]
    public class SalesController : ControllerBase
    {
        readonly ISaleService _saleService;
        public SalesController([FromServices] ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet("getallsales")]
        public async Task<OkObjectResult> GetSalesDataRange([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            string sales = _saleService.GetSalesBetweenRange(fromDate, toDate);
            return Ok(sales);
        }
    }
}
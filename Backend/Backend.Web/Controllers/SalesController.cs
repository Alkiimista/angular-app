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
        SaleService service;
        public SalesController()
        {
            service = new SaleService();
        }

        [HttpGet("getallsales")]
        public async Task<OkObjectResult> GetSalesDataRange()
        {
            string sales = service.GetSalesBetweenRange("", "");
            return Ok(sales);
        }
    }
}
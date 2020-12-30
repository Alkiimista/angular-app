using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    class SalesController : ControllerBase
    {
        public SalesController()
        {

        }

        public string GetAllSalesFromDataRange()
        {
            return "Sales";
        }
    }
}

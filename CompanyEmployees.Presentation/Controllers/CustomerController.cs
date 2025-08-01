using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CustomerController:ControllerBase
    {
        readonly IServiceManager _serviceManager;
        public CustomerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet (Name ="Customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _serviceManager.CustomerService.GetAllCustomersAsync());
        }

    }
}

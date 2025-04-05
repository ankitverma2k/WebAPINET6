using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        readonly IServiceManager _serviceManager;
        public CategoryController(IServiceManager serviceManager)
        {
                _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_serviceManager.CategoryService.GetCategories());
        }
    }
}

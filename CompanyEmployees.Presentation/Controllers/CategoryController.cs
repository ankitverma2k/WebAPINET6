using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
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

        [HttpPost]
        public IActionResult PostCategories([FromBody] CategoryDto categoryDto)
        {
           var categoryId= _serviceManager.CategoryService.AddCategory(categoryDto);

            return CreatedAtRoute("GetCategoryById", new { id = categoryId },value: categoryId);
        }

        [HttpGet("{id:guid}", Name = "GetCategoryById")]
        public IActionResult GetCategory(Guid id)
        {
            var category = _serviceManager.CategoryService.GetCategoryById(id);

            return Ok(category);

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.RequestFeatures;
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
        public async Task<IActionResult> GetCategory([FromQuery]  CategoryParameters categoryParameters)
        {
            return Ok(await _serviceManager.CategoryService.GetAllCategoriesAsync(categoryParameters));
        }

        [HttpPost]
        public async Task<IActionResult> PostCategories([FromBody] CategoryDto categoryDto)
        {
            var categoryId = await _serviceManager.CategoryService.AddCategoryAsync(categoryDto);
            return CreatedAtRoute("GetCategoryById", new { id = categoryId }, value: categoryId);
        }

        [HttpGet("{id:guid}", Name = "GetCategoryById")]
        public async Task<IActionResult> GetCategory(Guid id)
        {
            var category = await _serviceManager.CategoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _serviceManager.CategoryService.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryDto categoryDto)
        {
            await _serviceManager.CategoryService.UpdateCategoryAsync(categoryDto);
            return Ok();

        }
    }
}

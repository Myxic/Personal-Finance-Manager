using System;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetCategories();
            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetCategoryById(int categoryId)
        {
            var category = await _categoryService.GetCategoryById(categoryId);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryModel categoryModel)
        {
            var createdCategory = await _categoryService.CreateCategory(categoryModel);
            return CreatedAtAction(nameof(GetCategoryById), new { categoryId = createdCategory.CategoryId }, createdCategory);
        }

        [HttpPut("{categoryId}")]
        public async Task<IActionResult> UpdateCategory(int categoryId, CategoryModel categoryModel)
        {
            var updatedCategory = await _categoryService.UpdateCategory(categoryId, categoryModel);
            return Ok(updatedCategory);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            await _categoryService.DeleteCategory(categoryId);
            return NoContent();
        }
    }


}


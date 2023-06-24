using System;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Services.Interface;
using System.Security.Claims;
using Personal_Finance_Manager.Extension;

namespace Personal_Finance_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly IHttpContextAccessor _contextAccessor;

        public BudgetController(IBudgetService budgetService, IHttpContextAccessor contextAccessor)
        {
            _budgetService = budgetService;
            _contextAccessor = contextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> AddBudget(BudgetModel budgetModel)
        {
            string userId = _contextAccessor.HttpContext.User.GetUserId();

            budgetModel.UserId = userId;

            var addedBudget = await _budgetService.AddBudget(budgetModel);

            return Ok(addedBudget);
        }

        [HttpGet("{budgetId}")]
        public async Task<IActionResult> GetBudgetById(int budgetId)
        {
            var budget = await _budgetService.GetBudgetById(budgetId);
            if (budget == null)
            {
                return NotFound();
            }

            return Ok(budget);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetBudgetsByUserId(string userId)
        {
            var budgets = await _budgetService.GetBudgetsByUserId(userId);
            return Ok(budgets);
        }

        [HttpPut("{budgetId}")]
        public async Task<IActionResult> UpdateBudget(int budgetId, BudgetModel budgetModel)
        {
            if (budgetId != budgetModel.Id)
            {
                return BadRequest("Invalid budget ID");
            }

            var updatedBudget = await _budgetService.UpdateBudget(budgetModel);

            return Ok(updatedBudget);
        }

        [HttpDelete("{budgetId}")]
        public async Task<IActionResult> DeleteBudget(int budgetId)
        {
            await _budgetService.DeleteBudget(budgetId);

            return NoContent();
        }
    }

}


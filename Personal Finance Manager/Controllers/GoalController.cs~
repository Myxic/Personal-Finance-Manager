using System;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Services.Interface;
using System.Security.Claims;
using Personal_Finance_Manager.Model.DTOs.Requests;

namespace Personal_Finance_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GoalController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetGoalsByUserId(string userId)
        {
            var goals = await _goalService.GetGoalsByUserId(userId);
            return Ok(goals);
        }

        [HttpGet("{goalId}")]
        public async Task<IActionResult> GetGoalById(int goalId)
        {
            var goal = await _goalService.GetGoalById(goalId);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal([FromBody] GoalModel goalModel)
        {
            var goal = await _goalService.AddGoal(goalModel);
            return CreatedAtAction(nameof(GetGoalById), new { goalId = goal.GoalID }, goal);
        }

        [HttpPut("{goalId}")]
        public async Task<IActionResult> UpdateGoal(int goalId, [FromBody] GoalModel goalModel)
        {
            if (goalId != goalModel.GoalID)
            {
                return BadRequest();
            }

            try
            {
                var updatedGoal = await _goalService.UpdateGoal(goalModel);
                return Ok(updatedGoal);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{goalId}")]
        public async Task<IActionResult> DeleteGoal(int goalId)
        {
            try
            {
                await _goalService.DeleteGoal(goalId);
                return NoContent();
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }


}


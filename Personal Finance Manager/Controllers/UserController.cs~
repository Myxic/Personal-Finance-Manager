using System;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(string userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel userModel)
        {
            userModel.UserId = Guid.NewGuid(); // Generate a new Guid for the user
            var createdUser = await _userService.CreateUser(userModel);
            return CreatedAtAction(nameof(GetUserById), new { userId = createdUser.UserId }, createdUser);
        }


        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser(string userId, UserModel userModel)
        {
            var updatedUser = await _userService.UpdateUser(userId, userModel);
            return Ok(updatedUser);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            await _userService.DeleteUser(userId);
            return NoContent();
        }
    }

}


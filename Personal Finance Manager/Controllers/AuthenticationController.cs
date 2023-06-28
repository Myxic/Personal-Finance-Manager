using System;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserModel userModel)
        {
            var user = await _authenticationService.RegisterUser(userModel);

            if (user != null)
            {
                // Registration successful
                return Ok(user);
            }

            // Registration failed
            return BadRequest("Failed to register user.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserModel loginUser)
        {
            var user = await _authenticationService.Login(loginUser);

            if (user != null)
            {
                // Login successful
                return Ok(user);
            }

            // Login failed
            return BadRequest("Invalid username or password.");
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();

            // Logout successful
            return Ok();
        }

        [HttpGet("verify-email")]
        public async Task<IActionResult> VerifyEmail(EmailVerificationModel emailVerification)
        {
            var result = await _authenticationService.VerifyEmail(emailVerification);

            if (result)
            {
                // Email verification successful
                return Ok();
            }

            // Email verification failed
            return BadRequest("Failed to verify email.");
        }

    }

}


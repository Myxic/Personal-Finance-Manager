using System;
using Microsoft.AspNetCore.Identity;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Services.Impentation
{
  

    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public AuthenticationService(SignInManager<User> signInManager, UserManager<User> userManager, IEmailService emailService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
        }

        public async Task<User?> RegisterUser(RegisterUserModel userModel)
        {
            var user = new User
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                DOB = userModel.DOB,
                Email = userModel.EmailAddress
                // Set other properties as needed
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            if (result.Succeeded)
            {
                // Generate an email verification token
                var Emailtoken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                // Send the verification email to the user
                EmailVerificationModel emailVerification = new EmailVerificationModel()
                {
                    toEmail = user.Email,
                    token = Emailtoken               
                };

                await _signInManager.SignInAsync(user, isPersistent: false);

                await _emailService.SendVerificationEmail(emailVerification);

                // You can choose whether to automatically sign in the user after registration or require email verification first
                // For automatic sign-in, use:
                 

                return user;
            }

            return null;
        }

        public async Task<bool> VerifyEmail(EmailVerificationModel emailVerification)
        {
            var user = await _userManager.FindByIdAsync(emailVerification.userId);

            if (user == null)
            {
                return false;
            }

            var result = await _userManager.ConfirmEmailAsync(user, emailVerification.token);

            return result.Succeeded;
        }

        public async Task<User?> Login(LoginUserModel loginUser)
        {
            var result = await _signInManager.PasswordSignInAsync(loginUser.Username, loginUser.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginUser.Username);
                return user;
            }

            return null;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }


}


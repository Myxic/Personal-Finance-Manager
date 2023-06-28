using System;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;

namespace Personal_Finance_Manager.Services.Interface
{

        public interface IAuthenticationService
        {
            Task<User> RegisterUser(RegisterUserModel userModel);
            Task<User> Login(LoginUserModel loginUser);
            Task<bool> VerifyEmail(EmailVerificationModel emailVerification);
            Task Logout();
            
        }

}


using System;
using Personal_Finance_Manager.Model.DTOs.Requests;

namespace Personal_Finance_Manager.Services.Interface
{
    public interface IEmailService
    {
        Task<bool> SendVerificationEmail (EmailVerificationModel emailVerification);


        Task<bool> SendEmailAsync(EmailServiceModel serviceModel);
    }
}


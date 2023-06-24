using System;
using Personal_Finance_Manager.Services.Interface;
using FluentEmail.Core;
using FluentEmail.Smtp;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Microsoft.Extensions.Configuration;
using System.Net.Mail;
using System.Net;
using System.Xml.Linq;

namespace Personal_Finance_Manager.Services.Impentation
{

    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> SendEmailAsync(EmailServiceModel emailService)
        {
            // Retrieve email configuration from user secrets
            var smtpServer = _configuration["Email:SmtpServer"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"]??"");
            var smtpUsername = _configuration["Email:SmtpUsername"];
            var smtpPassword = _configuration["Email:SmtpPassword"];

            // Configure FluentEmail with SMTP settings
            Email.DefaultSender = new SmtpSender(() => new SmtpClient(smtpServer, smtpPort)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword)
            });

            // Send email
            var email = await Email
                .From("your_email@example.com")
                .To(emailService.toEmail)
                .Subject(emailService.subject)
                .Body(emailService.body)
                .SendAsync();

            

           if (email.Successful)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> SendVerificationEmail(EmailVerificationModel emailVerification)
        {
            

            var emailParams = new EmailServiceModel()
            {
                toEmail = emailVerification.toEmail,
                subject = "Email Verification",
                body = emailVerification.token
            };


            var result = await SendEmailAsync(emailParams);
            if (result == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}



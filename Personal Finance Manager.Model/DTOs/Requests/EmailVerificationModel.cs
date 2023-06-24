using System;
namespace Personal_Finance_Manager.Model.DTOs.Requests
{
    public class EmailVerificationModel
    {
        public string userId { get; set; }

        public string toEmail { get; set; }

	    public string token { get; set; }
    }
}


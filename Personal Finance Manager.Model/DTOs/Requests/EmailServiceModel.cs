using System;
namespace Personal_Finance_Manager.Model.DTOs.Requests
{
    public class EmailServiceModel
    {
        public string toEmail { get; set; }

        public string subject { get; set; }

        public string body { get; set; }
    }
}


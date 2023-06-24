using System;
namespace Personal_Finance_Manager.Model.DTOs.Requests
{
    public class RegisterUserModel
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

    }
}


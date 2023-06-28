using System;
using Microsoft.AspNetCore.Identity;

namespace Personal_Finance_Manager.Model.Enitities
{
     public class User : IdentityUser
    {
        public Guid UserID { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DOB { get; set; }

        public string EmailAddress { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }

        public virtual ICollection<Budget> Budgets { get; set; }

        public virtual ICollection<Goal> Goals { get; set; }

    }
}

 
using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Model.Enums;

namespace Personal_Finance_Manager.Model.Enitities
{
    public class Transaction
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int CategoryId { get; set; }

        public decimal Amount { get; set; }

        public TransactionType TransactionType { get; set; }

        public DateTime DateTime { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }

        public virtual Category Category { get; set; }
    }

}

//User user = dbContext.Users.Include(u => u.Transactions).FirstOrDefault(u => u.UserId == 1);





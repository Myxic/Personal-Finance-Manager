using System;
using Personal_Finance_Manager.Model.Enums;

namespace Personal_Finance_Manager.Model.DTOs.Requests
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTime { get; set; }
        public int CategoryId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
    }

}


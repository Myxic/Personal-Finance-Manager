using System;
namespace Personal_Finance_Manager.Model.DTOs.Requests
{
    public class BudgetModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

}


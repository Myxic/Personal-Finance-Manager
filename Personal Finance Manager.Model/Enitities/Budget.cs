using System;
namespace Personal_Finance_Manager.Model.Enitities
{
    public class Budget
    {
        public int BudgetID { get; set; }

        public string UserID { get; set; }

        public string BudgetName { get; set; }

        public decimal AmountAllocated { get; set; }

        public int CategoryId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual User User { get; set; }

    }
}


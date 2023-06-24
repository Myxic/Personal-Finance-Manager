using System;
namespace Personal_Finance_Manager.Model.Enitities
{
    public class Goal
    {

        public int GoalID { get; set; }

        public string UserID { get; set; }

        public string GoalName { get; set; }

        public decimal TargetAmount { get; set; }

        public decimal CurrentAmountSaved { get; set; }

        public DateTime TargetDate{get; set;}

        public virtual User User { get; set; }
    }
}


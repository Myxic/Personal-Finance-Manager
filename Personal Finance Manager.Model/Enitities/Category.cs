using System;
namespace Personal_Finance_Manager.Model.Enitities
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}


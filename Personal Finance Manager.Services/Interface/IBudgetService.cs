﻿using System;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;

namespace Personal_Finance_Manager.Services.Interface
{
    public interface IBudgetService
    {
        Task<Budget> AddBudget(BudgetModel budgetModel);
        Task<Budget> GetBudgetById(int budgetId);
        Task<IEnumerable<Budget>> GetBudgetsByUserId(string userId);
        Task<Budget> UpdateBudget(BudgetModel budgetModel);
        Task DeleteBudget(int budgetId);
    }


}


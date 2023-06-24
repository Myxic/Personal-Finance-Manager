using System;
using Personal_Finance_Manager.Data.Interfaces;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

namespace Personal_Finance_Manager.Services.Impentation
{
    public class BudgetService : IBudgetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Budget> _budgetRepository;

        public BudgetService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _budgetRepository = _unitOfWork.GetRepository<Budget>();
        }

        public async Task<Budget> AddBudget(BudgetModel budgetModel)
        {
            var budget = new Budget
            {
                UserID = budgetModel.UserId,
                CategoryId = budgetModel.CategoryId,
                AmountAllocated = budgetModel.Amount,
                StartDate = budgetModel.StartDate,
                EndDate = budgetModel.EndDate
            };

            await _budgetRepository.AddAsync(budget);
            await _unitOfWork.SaveChangesAsync();

            return budget;
        }

        public async Task<Budget> GetBudgetById(int budgetId)
        {
            var budget = await _budgetRepository.GetByIdAsync(budgetId);

            return budget;
        }

        public async Task<IEnumerable<Budget>> GetBudgetsByUserId(string userId)
        {
            var budgets = await _budgetRepository.GetByAsync(b => b.UserID == userId);

            return budgets;
        }

        public async Task<Budget> UpdateBudget(BudgetModel budgetModel)
        {
            var budget = await _budgetRepository.GetByIdAsync(budgetModel.Id);
            if (budget == null)
            {
                throw new FileNotFoundException("Budget not found");
            }

            budget.CategoryId = budgetModel.CategoryId;
            budget.AmountAllocated = budgetModel.Amount;
            budget.StartDate = budgetModel.StartDate;
            budget.EndDate = budgetModel.EndDate;

            await _unitOfWork.SaveChangesAsync();

            return budget;
        }

        public async Task DeleteBudget(int budgetId)
        {
            var budget = await _budgetRepository.GetByIdAsync(budgetId);
            if (budget == null)
            {
                throw new FileNotFoundException("Budget not found");
            }

            await _budgetRepository.DeleteAsync(budget);
            await _unitOfWork.SaveChangesAsync();
        }

       
    }

}


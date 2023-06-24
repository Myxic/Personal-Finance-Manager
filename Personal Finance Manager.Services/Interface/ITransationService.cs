using System;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;

namespace Personal_Finance_Manager.Services.Interface
{
    public interface ITransactionService
    {
        Task<Transaction> AddTransaction(TransactionModel transactionModel);

        Task<Transaction> UpdateTransaction(TransactionModel transactionModel);

        Task DeleteTransaction(int transactionId);

        Task<Transaction> GetTransactionById(int transactionId);

        Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId);

        Task<IEnumerable<Transaction>> GetTransactionsByCategory(string userId, int categoryId);

        Task<IEnumerable<Transaction>> GetTransactionsByDateRange(string userId, DateTime startDate, DateTime endDate);

        Task<decimal> GetTotalExpenseByUserId(string userId);

        Task<decimal> GetTotalIncomeByUserId(string userId);
    }
}


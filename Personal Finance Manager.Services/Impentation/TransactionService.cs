using System;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;
using Personal_Finance_Manager.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Personal_Finance_Manager.Model.Enums;

namespace Personal_Finance_Manager.Services.Impentation
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Transaction> _transaction;
        
        private readonly ApplicationDbContext _dbContext;

        public TransactionService(IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor, ApplicationDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
          
            _transaction = _unitOfWork.GetRepository<Transaction>();
            _dbContext = dbContext;
        }

        public async Task<Transaction> AddTransaction(TransactionModel transactionModel)
        {
            var transaction = new Transaction
            {
                UserId = transactionModel.UserId,
                TransactionType = transactionModel.TransactionType,
                Amount = transactionModel.Amount,
                DateTime = transactionModel.DateTime,
                CategoryId = transactionModel.CategoryId,
                StartDate = transactionModel.StartDate,
                EndDate = transactionModel.EndDate,
                Description = transactionModel.Description
            };


            await _transaction.AddAsync(transaction);

            await _unitOfWork.SaveChangesAsync();

            return transaction;


        }

        public async Task DeleteTransaction(int transactionId)
        {
            var transaction = await _transaction.GetByIdAsync(transactionId);
            if (transaction != null)
            {

                await _transaction.DeleteAsync(transaction);
                await _unitOfWork.SaveChangesAsync();
            }
             throw new FileNotFoundException("Transaction not found");
            // Added an error message later
        }

        public async Task<decimal> GetTotalExpenseByUserId(string userId)
        {
            var totalExpense = await _dbContext.Transactions
           .Where(t => t.UserId == userId && t.TransactionType == TransactionType.Expense)
           .SumAsync(t => t.Amount);

            return totalExpense;
        }

        public async Task<decimal> GetTotalIncomeByUserId(string userId)
        {
            var totalExpense = await _dbContext.Transactions
          .Where(t => t.UserId == userId && t.TransactionType == TransactionType.Income)
          .SumAsync(t => t.Amount);

            return totalExpense;
        }

        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            var transaction =  await _transaction.GetByIdAsync(transactionId);

            return transaction;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByCategory(string userId, Category category)
        {
            var transactions = await _transaction.GetAllAsync(include: t => (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Transaction, object>)t.Include(u => u.UserId == userId).Select(u => u.Category == category).ToListAsync());
            return transactions;

            //return await _dbContext.Transactions
            //.Where(t => t.UserId == userId && t.Category == category)
            //.ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByCategory(int categoryId)
        {
            var transactions = await _transaction.GetByAsync(t => t.CategoryId == categoryId);

            return transactions;
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByDateRange(string userId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _transaction.GetAllAsync(include: t => (Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<Transaction, object>)t.Include(u => u.UserId == userId).Select(u => u.StartDate >= startDate && u.EndDate <= endDate).ToListAsync());
            return transactions;
        }

      

        public async Task<IEnumerable<Transaction>> GetTransactionsByUserId(string userId)
        {
            var transaction = await _transaction.GetByAsync(t => t.UserId == userId);

            return transaction;
        }

        public async Task<Transaction> UpdateTransaction(TransactionModel transactionModel)
        {
            var transaction = await _transaction.GetByIdAsync(transactionModel.Id);
            if (transaction == null)
            {
                throw new FileNotFoundException("Transaction not found");
            }

            transaction.TransactionType = transactionModel.TransactionType;
            transaction.Amount = transactionModel.Amount;
            transaction.DateTime = transactionModel.DateTime;
            transaction.CategoryId = transactionModel.CategoryId;
            transaction.StartDate = transactionModel.StartDate;
            transaction.EndDate = transactionModel.EndDate;
            transaction.Description = transactionModel.Description;

            await _unitOfWork.SaveChangesAsync();

            return transaction;
        }
    }
}


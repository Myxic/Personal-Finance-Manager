using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal_Finance_Manager.Model.DTOs.Requests;
using Personal_Finance_Manager.Model.Enitities;
using Personal_Finance_Manager.Services.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Personal_Finance_Manager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IHttpContextAccessor _contextAccessor;

        public TransactionController(ITransactionService transactionService, IHttpContextAccessor contextAccessor)
        {
            _transactionService = transactionService;
            _contextAccessor = contextAccessor;
        }

        // GET: api/transaction/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaction>> GetTransactionById(int id)
        {
            var transaction = await _transactionService.GetTransactionById(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // POST: api/transaction
        [HttpPost]
        public async Task<ActionResult<Transaction>> AddTransaction(TransactionModel transactionModel)
        {
            var transaction = await _transactionService.AddTransaction(transactionModel);

            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        // PUT: api/transaction/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, TransactionModel transactionModel)
        {
            if (id != transactionModel.Id)
            {
                return BadRequest();
            }

            try
            {
                var updatedTransaction = await _transactionService.UpdateTransaction(transactionModel);
                return Ok(updatedTransaction);
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/transaction/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            try
            {
                await _transactionService.DeleteTransaction(id);
                return NoContent();
            }
            catch (FileNotFoundException)
            {
                return NotFound();
            }
        }

        // GET: api/transaction/expense/{userId}
        [HttpGet("expense/{userId}")]
        public async Task<ActionResult<decimal>> GetTotalExpenseByUserId(string userId)
        {
            var totalExpense = await _transactionService.GetTotalExpenseByUserId(userId);

            return Ok(totalExpense);
        }

        // GET: api/transaction/income/{userId}
        [HttpGet("income/{userId}")]
        public async Task<ActionResult<decimal>> GetTotalIncomeByUserId(string userId)
        {
            var totalIncome = await _transactionService.GetTotalIncomeByUserId(userId);

            return Ok(totalIncome);
        }

        // GET: api/transaction/category/{userId}/{categoryId}
        [HttpGet("category/{userId}/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByCategory(string userId, int categoryId)
        {
            var transactions = await _transactionService.GetTransactionsByCategory(userId, categoryId);

            return Ok(transactions);
        }

        // GET: api/transaction/daterange/{userId}/{startDate}/{endDate}
        [HttpGet("daterange/{userId}/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactionsByDateRange(string userId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _transactionService.GetTransactionsByDateRange(userId, startDate, endDate);

            return Ok(transactions);
        }
    }


}


//Note to self: later try and use "IHttpContextAccessor contextAccessor" but that means you will remove userId so that you can use "IHttpContextAccessor contextAccessor" to call userId personally

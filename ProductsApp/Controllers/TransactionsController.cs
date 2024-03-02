using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.DataAccess.Context;
using ProductsApp.Interfaces;

namespace ProductsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService) 
        {
            _transactionService = transactionService;
        }
        [HttpPost("SaveTransactions")]
        public IActionResult SaveTransactions([FromBody] List<Transaction> transactions)
        {
            try
            {
                _transactionService.SaveTransactions(transactions);
                return Ok($"Transaction {transactions.First().TransactionId} is saved");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

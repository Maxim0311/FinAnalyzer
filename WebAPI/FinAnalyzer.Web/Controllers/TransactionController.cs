using FinAnalyzer.Core.Dto.Transaction;
using FinAnalyzer.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinAnalyzer.Web.Controllers
{
    [Route("api/transaction")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        /// <summary>
        /// Добавить доход
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("make-income-transaction")]
        public async Task<IActionResult> MakeIncomeTransaction(TransactionIncomeCreateRequest request)
        {
            var result = await _transactionService.MakeIncomeTransaction(request);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Добавить расход
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("make-expend-transaction")]
        public async Task<IActionResult> MakeExpendTransaction(TransactionExpendCreateRequest request)
        {
            var result = await _transactionService.MakeExpendTransaction(request);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// Совершить перевод
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("make-person-transaction")]
        public async Task<IActionResult> MakePersonTransaction(TransactionPersonCreateRequest request)
        {
            var result = await _transactionService.MakePersonTransaction(request);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}

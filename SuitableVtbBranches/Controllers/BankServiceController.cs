using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SuitableVtbBranches.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/bank-services")]
    public class BankServiceController : ControllerBase
    {
        private readonly IBankServiceService _bankServiceService;

        public BankServiceController(IBankServiceService bankServiceService) {
            _bankServiceService = bankServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _bankServiceService.GetList();
            return Ok(result);
        }
    }
}
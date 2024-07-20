using LoanApp.Server.Models;
using LoanApp.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController(ILoanService loanService) 
        : ControllerBase
    {
        [HttpPost("GetLoanSuggestion")]
        public LoanSuggestionResponse GetLoanSuggestion([FromBody]LoanSuggestionRequest request)
        {
            return loanService.GetLoanSuggestion(request);
        }
    }
}

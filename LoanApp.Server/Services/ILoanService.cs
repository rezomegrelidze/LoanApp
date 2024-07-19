using LoanApp.Server.Models;

namespace LoanApp.Server.Services;

public interface ILoanService
{
    LoanSuggestionResponse GetLoanSuggestion(LoanSuggestionRequest request);
}
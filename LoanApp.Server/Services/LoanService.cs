using LoanApp.Server.Models;

namespace LoanApp.Server.Services;

public class LoanService : ILoanService
{
    public LoanSuggestionResponse GetLoanSuggestion(LoanSuggestionRequest request)
    {
        if (request.LoanPeriodInMonths < 12)
        {
            return new()
            {
                Success = false,
                Message = "Loan period must be minimum 12 months"
            };
        }

        // interest calculation logic based on age and amount. 
        var prime = 0.015m;
        var interest = request.Age switch
        {
            < 20 => 0.02m + prime,
            <= 35 => request.Amount switch
            {
                <= 5000 => 0.02m,
                <= 30000 => 0.015m + prime,
                _ => 1 + prime
            },
            _ => request.Amount switch
            {
                <= 15000 => 0.015m + prime,
                <= 30000 => 0.03m + prime,
                _ => 0.01m
            }
        } + (request.LoanPeriodInMonths - 12) * 0.0015m;
        // add also 0.15% extra for each extra month after 12 months

        return new()
        {
            Success = true,
            TotalAmountToPay = request.Amount + request.Amount * interest,
            Message = string.Empty
        };
    }
}
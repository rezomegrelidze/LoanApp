namespace LoanApp.Server.Models;

public class LoanSuggestionResponse
{
    public decimal TotalAmountToPay { get; set; }
    public string Message { get; set; }
    public bool Success { get; set; }
}
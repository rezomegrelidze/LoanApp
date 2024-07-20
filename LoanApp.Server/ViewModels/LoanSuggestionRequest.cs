namespace LoanApp.Server.Models
{
    public class LoanSuggestionRequest
    {
        public int Age { get; set; }
        public decimal Amount { get; set; }
        public int LoanPeriodInMonths{ get; set; }
    }
}

using LoanApp.Server.Models;

namespace LoanApp.Server.ViewModels;

public class GetUserResponse
{
    public User User { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}

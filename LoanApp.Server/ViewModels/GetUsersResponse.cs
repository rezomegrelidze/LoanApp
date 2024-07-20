using LoanApp.Server.Models;

namespace LoanApp.Server.ViewModels;

public class GetUsersResponse
{
    public List<User> Users { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
}
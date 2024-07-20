using LoanApp.Server.Models;

namespace LoanApp.Server.Repositories;

public interface IUserRepository
{
    User? GetUser(int userId);
    List<User> GetUsers();
}
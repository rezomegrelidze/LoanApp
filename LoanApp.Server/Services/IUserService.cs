using LoanApp.Server.ViewModels;

namespace LoanApp.Server.Services;

public interface IUserService
{
    GetUserResponse GetUser(GetUserRequest request);
    GetUsersResponse GetUsers(GetUsersRequest request);
}
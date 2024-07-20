using LoanApp.Server.Repositories;
using LoanApp.Server.ViewModels;

namespace LoanApp.Server.Services;

public class UserService(IUserRepository repository) : IUserService
{
    public GetUserResponse GetUser(GetUserRequest request)
    {
        var user = repository.GetUser(request.UserId);
        if (user is null)
        {
            return new()
            {
                Success = false,
                Message = $"User with id {request.UserId} was not found"
            };
        }

        return new()
        {
            User = user,
            Success = true,
            Message = ""
        };
    }

    public GetUsersResponse GetUsers(GetUsersRequest request)
    {
        var users = repository.GetUsers();

        return new()
        {
            Users = users ?? [],
            Success = true,
            Message = ""
        };
    }
}
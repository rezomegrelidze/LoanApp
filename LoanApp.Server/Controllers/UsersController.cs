using LoanApp.Server.Models;
using LoanApp.Server.Services;
using LoanApp.Server.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoanApp.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(IUserService userService)
        : ControllerBase
    {
        [HttpPost("GetUser")]
        public GetUserResponse GetUser(GetUserRequest request)
        {
            return userService.GetUser(request);
        }

        [HttpPost("GetUsers")]
        public GetUsersResponse GetUsers(GetUsersRequest request)
        {
            return userService.GetUsers(request);
        }
    }
}

using System.Collections.Concurrent;
using LoanApp.Server.Models;

namespace LoanApp.Server.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ConcurrentDictionary<int, User> users = new();

        public UserRepository()
        {
            // initialize dictionary with initial users
            var initialUsers = new User[]
            {
                new ()
                {
                    Age = 19,
                    Name = "John Doe"
                },
                new ()
                {
                    Age = 30,
                    Name = "Jane Doe"
                },
                new ()
                {
                    Age = 36,
                    Name = "Paul Smith"
                }
            };

            foreach (var user in initialUsers)
            {
                users[user.Id] = user;
            }
        }


        public User? GetUser(int userId)
        {
            return users.GetValueOrDefault(userId);
        }

        public List<User> GetUsers()
        {
            return users.Values.ToList();
        }
    }
}

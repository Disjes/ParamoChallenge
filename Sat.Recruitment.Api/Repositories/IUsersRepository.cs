using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repositories
{
    public interface IUsersRepository
    {
        Task AddUserAsync(User user);
        List<User> GetAllUsers();
        bool UserExists(string email);
    }
}
using Sat.Recruitment.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Repositories
{
    public interface IUsersRepository
    {
        Task AddUserAsync(User user);
        Task<bool> UserExists(string email);
    }
}
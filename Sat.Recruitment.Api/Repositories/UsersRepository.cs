using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sat.Recruitment.Api.Factories;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Utils;

namespace Sat.Recruitment.Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private static readonly string path = $"{Directory.GetCurrentDirectory()}/Files/Users.txt";
        public UsersRepository()
        {
            
        }
        
        public async Task<bool> UserExists(string email)
        {
            using var reader = File.OpenText(path);
            while (reader.Peek() >= 0)
            {
                var line = await reader.ReadLineAsync();
                var lineArray = line.Split(',');
                if (string.IsNullOrEmpty(line))
                {
                    break;
                }
                var userRecord = new User
                {
                    Name = lineArray[0],
                    Email = lineArray[1],
                    Phone = lineArray[2],
                    Address = lineArray[3],
                    UserType = lineArray[4],
                    Money = decimal.Parse(line.Split(',')[5]),
                };
                if (userRecord.Email == email)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task AddUserAsync(User user)
        {
            await using var writer = File.AppendText(path);
            var concreteUser = UserFactory.Create(name: user.Name, email: user.Email,
                address: user.Address, phone: user.Phone, userType: user.UserType, money: user.Money);
            var fields = typeof(User).GetProperties();
            var userString = String.Join(",", fields.Select(f => f.GetValue(concreteUser)));
            await writer.WriteLineAsync($"{Environment.NewLine}{userString}");
        }
    }
}
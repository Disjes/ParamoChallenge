using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Utils;

namespace Sat.Recruitment.Api.Repositories
{
    public class UsersRepository : IUsersRepository
    {

        public UsersRepository()
        {

        }

        public bool UserExists(string email)
        {
            var reader = IOManager.CreateStreamReader();
            try
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var userRecord = new User
                    {
                        Name = line.Split(',')[0],
                        Email = line.Split(',')[1],
                        Phone = line.Split(',')[2],
                        Address = line.Split(',')[3],
                        UserType = line.Split(',')[4],
                        Money = decimal.Parse(line.Split(',')[5]),
                    };
                    if (userRecord.Email == email)
                    {
                        return true;
                    }
                }
                reader.Close();
            }
            catch
            {

            }
            return false;
        }

        public List<User> GetAllUsers()
        {
            var _users = new List<User>();
            var reader = IOManager.CreateStreamReader();
            try
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;
                    var userRecord = new User
                    {
                        Name = line.Split(',')[0],
                        Email = line.Split(',')[1],
                        Phone = line.Split(',')[2],
                        Address = line.Split(',')[3],
                        UserType = line.Split(',')[4],
                        Money = decimal.Parse(line.Split(',')[5]),
                    };
                    _users.Add(userRecord);
                }

                reader.Close();
            }
            catch
            {

            }

            return _users;
        }

        public async Task AddUserAsync(User user)
        {
            var writer = IOManager.CreateStreamWriter();
            var fields = typeof(User).GetProperties();
            var userString = String.Join(",", fields.Select(f => f.GetValue(user)));
            await writer.WriteLineAsync(userString);
            writer.Close();
        }
    }
}
using System;
using System.Threading.Tasks;
using FluentAssertions;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Utils;
using Xunit;

namespace Sat.Recruitment.Test.Integration
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserRepositoryTests : IDisposable
    {
        [Fact]
        public async Task UserExistsReturnsTrueWhenExistingEmailPassed()
        {
            //Arrange
            var userRepository = new UsersRepository();
            var email = "Franco.Perez@gmail.com";

            //Act
            var userExists = await userRepository.UserExists(email);
            
            //Assert
            userExists.Should().BeTrue();
        }

        [Fact]
        public async Task AddUserSavesUserWhenValidObjectIsPassed()
        {
            //Arrange
            var userRepository = new UsersRepository();
            var user = new User()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            //Act
            await userRepository.AddUserAsync(user);
            var userExists = await userRepository.UserExists(user.Email);

            //Assert
            userExists.Should().BeTrue();
        }

        public void Dispose()
        {
        }
    }
}
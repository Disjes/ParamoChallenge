using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Xunit;

namespace Sat.Recruitment.Test.Unit
{
    [CollectionDefinition("Tests")]
    public class UserControllerTests
    {
        [Fact]
        public async void PostReturnsCreatedWhenValidRequest()
        {
            //Arrange
            var userRepositoryMock = Substitute.For<IUsersRepository>();
            userRepositoryMock.AddUserAsync(Arg.Any<User>()).Returns(Task.CompletedTask);
            var userController = new UsersController(userRepositoryMock);
            userController.ModelState.Clear();
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
            var result = await userController.Post(user) as ObjectResult;

            //Assert
            result.StatusCode.Should().Be(201);
            result.Value.Should().BeEquivalentTo(user, options =>
                options.Excluding(u => u.Email)
                .Excluding(u => u.Money)
            );
        }

        [Fact]
        public async void PostReturnsConflictWhenDuplicateEntry()
        {
            //Arrange
            var userRepositoryMock = Substitute.For<IUsersRepository>();
            userRepositoryMock.UserExists(Arg.Any<string>()).Returns(true);
            var userController = new UsersController(userRepositoryMock);
            userController.ModelState.Clear();
            var user = new User();
            
            //Act
            var result = await userController.Post(user) as ObjectResult;

            //Assert
            result.StatusCode.Should().Be(409);
            result.Value.Should().Be("The user already exists");
        }
    }
}

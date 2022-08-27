using System;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Sat.Recruitment.Api.Controllers;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Xunit;
using System.Threading.Tasks;

namespace Sat.Recruitment.Tests
{
    public class UnitTest1
    {
        [Fact]
        public async void PostReturnsCreatedWhenValidRequest()
        {
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
            var result = await userController.Post(user) as ObjectResult;

            result.StatusCode.Should().Be(201);
            result.Value.Should().BeEquivalentTo(user, options => 
                options.Excluding(u => u.Email)
                .Excluding(u => u.Money)
            );
        }

        [Fact]
        public async void PostReturnsConflictWhenDuplicateEntry()
        {
            var userRepositoryMock = Substitute.For<UsersRepository>();
            var userController = new UsersController(userRepositoryMock);
            
            var user = new User()
            {
                Address = "Av. Juan G",
                Email = "Agustina@gmail.com",
                Name = "Agustina",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            
            var result = await userController.Post(user) as ObjectResult;

            //Client should understand that a Conflict(409) response means there's a duplicate entry.
            result.StatusCode.Should().Be(409);
        }
    }
}
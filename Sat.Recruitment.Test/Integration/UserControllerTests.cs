using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using Sat.Recruitment.Api.Models;
using Sat.Recruitment.Api.Repositories;
using Sat.Recruitment.Api.Utils;
using Xunit;

namespace Sat.Recruitment.Test.Integration
{
    [CollectionDefinition("Tests", DisableParallelization = true)]
    public class UserControllerTests : IClassFixture<CustomWebApplicationFactory<Api.Startup>>, IDisposable
    {
        private readonly CustomWebApplicationFactory<Api.Startup> _factory;

        public UserControllerTests(CustomWebApplicationFactory<Api.Startup> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async Task PostUserReturnsCreatedWhenValidRequest()
        {
            // Arrange
            var client = _factory.CreateClient();
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/Users");
            var user = new User()
            {
                Address = "Av. Juan G",
                Email = "david@gmail.com",
                Name = "David",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };
            var json = JsonConvert.SerializeObject(user);
            postRequest.Content = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.SendAsync(postRequest);
            
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            var userFromResponse = JsonConvert.DeserializeObject<User>(responseString);

            response.StatusCode.Should().Be(HttpStatusCode.Created);
            userFromResponse.Should().BeEquivalentTo(user, options =>
                options.Excluding(u => u.Email)
                    .Excluding(u => u.Money)
            );
        }

        public void Dispose()
        {
        }
    }
}
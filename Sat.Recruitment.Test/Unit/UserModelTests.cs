using FluentAssertions;
using Sat.Recruitment.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Sat.Recruitment.Api.Factories;
using Xunit;

namespace Sat.Recruitment.Test.Unit
{
    public class UserModelTests
    {

        [Theory]
        [InlineData("Name")]
        [InlineData("Address")]
        [InlineData("Phone")]
        [InlineData("Email")]
        public void ModelBindingReturnsRequiredErrorsWhenPassingNullValues(string property)
        {
            //Arrange
            var message = "required";
            var user = new User()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 124
            };

            var field = typeof(User).GetProperties().Single(x => x.Name == property);
            if(field != null)
            {
                field.SetValue(user, null);
            }

            //Act
            var validation = ValidateModel(user);

            //Assert
            validation.Should()
                .Contain(x => x.MemberNames.Contains(property) && x.ErrorMessage.Contains(message));
        }

        [Fact]
        public void ModelBindingReturnsNoErrorsWhenPassingValidValues()
        {
            //Arrange
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
            var validation = ValidateModel(user);

            //Assert
            validation.Should().BeEmpty();
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}

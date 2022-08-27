using FluentAssertions;
using Sat.Recruitment.Api.Models;
using Xunit;

namespace Sat.Recruitment.Test.Unit
{
    public class SuperUserTests
    {
        [Fact]
        public void MoneyPropertyIsSetToRightValueWhenBetween10And100()
        {
            //Arrange
            var expectedMoneyValue = (decimal)126; //(105 * 0.20) = 21 + 105 = 126
            
            //Act
            var superUser = new SuperUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 105
            };
            
            //Assert
            superUser.Money.Should().Be(expectedMoneyValue);
        }
        
        [Fact]
        public void MoneyPropertyIsSetUnchangedWhenNoConditionMet()
        {
            //Arrange
            var expectedMoneyValue = (decimal)99; 
            
            //Act
            var superUser = new SuperUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 99
            };
            
            //Assert
            superUser.Money.Should().Be(expectedMoneyValue);
        }
    }
}
using FluentAssertions;
using Sat.Recruitment.Api.Models;
using Xunit;

namespace Sat.Recruitment.Test.Unit
{
    public class PremiumUserTests
    {
        [Fact]
        public void MoneyPropertyIsSetToRightValueWhenBetween10And100()
        {
            //Arrange
            var expectedMoneyValue = (decimal)315; //(105 * 2) = 210 + 105 = 315
            
            //Act
            var premiumUser = new PremiumUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 105
            };
            
            //Assert
            premiumUser.Money.Should().Be(expectedMoneyValue);
        }
        
        [Fact]
        public void MoneyPropertyIsSetUnchangedWhenNoConditionMet()
        {
            //Arrange
            var expectedMoneyValue = (decimal)99; 
            
            //Act
            var premiumUser = new PremiumUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Premium",
                Money = 99
            };
            
            //Assert
            premiumUser.Money.Should().Be(expectedMoneyValue);
        }
    }
}
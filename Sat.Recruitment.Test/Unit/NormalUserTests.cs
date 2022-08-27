using System.Threading.Tasks;
using FluentAssertions;
using Sat.Recruitment.Api.Models;
using Xunit;

namespace Sat.Recruitment.Test.Unit
{
    public class NormalUserTests
    {
        [Fact]
        public void MoneyPropertyIsSetToRightValueWhenBetween10And100()
        {
            //Arrange
            var expectedMoneyValue = (decimal)27; //(15 * 0.8) = 12 + 15 = 27
            
            //Act
            var normalUser = new NormalUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 15
            };
            
            //Assert
            normalUser.Money.Should().Be(expectedMoneyValue);
        }

        [Fact]
        public void MoneyPropertyIsSetToRightValueWhenAbove100()
        {
            //Arrange
            var expectedMoneyValue = (decimal)117.6; //(105 * 0.12) = 12.6 + 105 = 117.6
            
            //Act
            var normalUser = new NormalUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 105
            };
            
            //Assert
            normalUser.Money.Should().Be(expectedMoneyValue);
        }
        
        [Fact]
        public void MoneyPropertyIsSetUnchangedWhenNoConditionMet()
        {
            //Arrange
            var expectedMoneyValue = (decimal)5;
            
            //Act
            var normalUser = new NormalUser()
            {
                Address = "Av. Juan G",
                Email = "mike@gmail.com",
                Name = "Mike",
                Phone = "+349 1122354215",
                UserType = "Normal",
                Money = 5
            };
            
            //Assert
            normalUser.Money.Should().Be(expectedMoneyValue);
        }
    }
}
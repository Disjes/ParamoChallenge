using System;
using Microsoft.AspNetCore.Http;
using Sat.Recruitment.Api.Models;

namespace Sat.Recruitment.Api.Factories
{
    public static class UserFactory 
    {
        public static User Create(string name, string email, string address, string phone, string userType, decimal money)
        {
            User user;
            switch (userType)
            {
                case "Normal": 
                    user = new NormalUser();
                    break;
                case "Super": 
                    user =  new SuperUser();
                    break;
                case "Premium": 
                    user =  new PremiumUser();
                    break;
                default: throw new ArgumentException("Invalid type", "type");
            }

            fillUserPropertyValues(ref user, name, email, address, phone, userType, money);
            
            return user;
        }

        private static void fillUserPropertyValues(ref User user, string name, string email, string address, 
            string phone, string userType, decimal money)
        {
            user.Address = address;
            user.Email = email;
            user.Name = name;
            user.Phone = phone;
            user.UserType = userType;
            user.Money = money;
        }
    }
}
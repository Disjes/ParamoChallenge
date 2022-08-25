using System;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Models
{
    public class User
    {
        
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The email is required")]
        public string Email {
            get => Email;
            set
            {
                //Normalize email
                var aux = Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                Email = string.Join("@", new string[] { aux[0], aux[1].ToLower() });
            } 
        }
        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The phone is required")]
        public string Phone { get; set; }
        public string UserType { get; set; }

        public decimal Money
        {
            get => this.Money;
            set
            {
                const int limit = 100;
                const decimal normalUserBelowLimitPercentage = (decimal)0.8;
                const decimal normalUserAboveLimitPercentage = (decimal)0.12;
                const decimal superUserPercentage = (decimal)0.20;
                const decimal premiumPercentage = 2;

                if (UserType == "Normal")
                {
                    if (Money > limit)
                    {
                        //If new user is normal and has more than USD100
                        var gif = Money * normalUserAboveLimitPercentage;
                        Money = Money + gif;
                    }
                    if (Money < limit)
                    {
                        if (Money > 10)
                        {
                            var gif = Money * normalUserBelowLimitPercentage;
                            Money = Money + gif;
                        }
                    }
                }
                if (UserType == "SuperUser")
                {
                    if (Money > limit)
                    {
                        var gif = Money * superUserPercentage;
                        Money = Money + gif;
                    }
                }
                if (UserType == "Premium")
                {
                    if (Money > limit)
                    {
                        var gif = Money * premiumPercentage;
                        Money = Money + gif;
                    }
                }
            }
        }
    }
}
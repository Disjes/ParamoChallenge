using System;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Models
{
    public class User
    {
        
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        private string _Email;
        [Required(ErrorMessage = "The email is required")]
        public string Email {
            get => _Email;
            set
            {
                _Email = value;
                if(value != null)
                {
                    //Normalize email
                    var aux = value.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);
                    _Email = string.Join("@", new string[] { aux[0], aux[1].ToLower() });
                }
            } 
        }
        [Required(ErrorMessage = "The address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "The phone is required")]
        public string Phone { get; set; }
        public string UserType { get; set; }
        private decimal _Money;
        public decimal Money
        {
            get => this._Money;
            set
            {
                const int limit = 100;
                const decimal normalUserBelowLimitPercentage = (decimal)0.8;
                const decimal normalUserAboveLimitPercentage = (decimal)0.12;
                const decimal superUserPercentage = (decimal)0.20;
                const decimal premiumPercentage = 2;

                if (UserType == "Normal")
                {
                    if (value > limit)
                    {
                        //If new user is normal and has more than USD100
                        var gif = value * normalUserAboveLimitPercentage;
                        _Money = value + gif;
                    }
                    if (value < limit)
                    {
                        if (value > 10)
                        {
                            var gif = value * normalUserBelowLimitPercentage;
                            _Money = value + gif;
                        }
                    }
                }
                if (UserType == "SuperUser")
                {
                    if (value > limit)
                    {
                        var gif = value * superUserPercentage;
                        _Money = value + gif;
                    }
                }
                if (UserType == "Premium")
                {
                    if (value > limit)
                    {
                        var gif = value * premiumPercentage;
                        _Money = value + gif;
                    }
                }
            }
        }
    }
}
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
                if(value != null && new EmailAddressAttribute().IsValid(value))
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
        private decimal _money;
        public decimal Money
        {
            get => _money;
            set => SetMoney(value);
        }

        protected virtual void SetMoney(decimal money)
        {
            _money = money;
        }

        internal void ApplyPercentage(decimal money, decimal percentage)
        {
            var gif = money * percentage;
            _money = money + gif;
        }
    }
}
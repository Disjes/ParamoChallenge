using System;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Models
{
    public class NormalUser : User
    {
        protected override void SetMoney(decimal money)
        {
            const int limit = 100;
            const decimal normalUserBelowLimitPercentage = (decimal)0.8;
            const decimal normalUserAboveLimitPercentage = (decimal)0.12;
            
            
            if (money > limit)
            {
                //If new user is normal and has more than USD100
                ApplyPercentage(money, normalUserAboveLimitPercentage);
                return;
            }
            if (money > 10 && money < limit)
            {
                ApplyPercentage(money, normalUserBelowLimitPercentage);
                return;
            }
            base.SetMoney(money);
        }
    }
}
namespace Sat.Recruitment.Api.Models
{
    public class PremiumUser : User
    {
        protected override void SetMoney(decimal money)
        {
            const int limit = 100;
            const decimal premiumUserPercentage = (decimal)2;
            if (money > limit)
            {
                ApplyPercentage(money, premiumUserPercentage);
                return;
            }
            base.SetMoney(money);
        }
    }
}
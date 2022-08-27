namespace Sat.Recruitment.Api.Models
{
    public class SuperUser : User
    {
        protected override void SetMoney(decimal money)
        {
            const int limit = 100;
            const decimal superUserPercentage = (decimal)0.20;
            if (money > limit)
            {
                ApplyPercentage(money, superUserPercentage);
                return;
            }
            base.SetMoney(money);
        }
    }
}
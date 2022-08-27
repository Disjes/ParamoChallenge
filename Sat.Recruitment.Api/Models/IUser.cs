using System.IO;

namespace Sat.Recruitment.Api.Models
{
    public interface IUser
    {
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string UserType { get; set; }
        decimal Money { get; set; }

        public void SetMoney(decimal money);
    }
}
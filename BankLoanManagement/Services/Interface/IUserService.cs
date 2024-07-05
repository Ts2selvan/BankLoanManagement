using BankLoanManagement.Models;

namespace BankLoanManagement.Services.Interface
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, byte[] password);
        Task<User> Register(User user, byte[] password);
    }
}

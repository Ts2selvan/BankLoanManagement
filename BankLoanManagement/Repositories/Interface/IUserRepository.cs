using BankLoanManagement.Models;

namespace BankLoanManagement.Repositories.Interface
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, byte[] password);
        Task<User> Register(User user, byte[] password);

    }
}

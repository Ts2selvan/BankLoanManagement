using BankLoanManagement.Models;
using BankLoanManagement.Repositories.Interface;

namespace BankLoanManagement.Repositories
{
    public class USerRepository : IUserRepository
    {
        private readonly  BankLoanDbContext _bankLoanDbContext;
        public USerRepository(BankLoanDbContext bankLoanDbContext)
        {
            _bankLoanDbContext = bankLoanDbContext;
        }
      

        public Task<User> Authenticate(string username, byte[] password)
        {
            var user=_bankLoanDbContext.
        }

      

        public Task<User> Register(User user, byte[] password)
        {
           
        }
    }
}

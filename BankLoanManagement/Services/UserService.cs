using BankLoanManagement.Models;
using BankLoanManagement.Repositories.Interface;
using BankLoanManagement.Services.Interface;

namespace BankLoanManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      

        public Task<User> Authenticate(string username, byte[] password)
        {
            return _userRepository.Authenticate(username, password);
        }

        

        public Task<User> Register(User user, byte[] password)
        {
          return _userRepository.Register(user, password);
        }
    }
}

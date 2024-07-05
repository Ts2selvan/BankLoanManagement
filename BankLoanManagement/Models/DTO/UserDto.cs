namespace BankLoanManagement.Models.DTO
{
    public class UserDto
    {
        public class UserLoginDto
        {

            public string Username { get; set; } = null!;

            public byte[] PasswordHash { get; set; } = null!;
        }
        public class UserRegisterDto
        {

            public string Username { get; set; } = null!;

            public byte[] PasswordHash { get; set; } = null!;
        }
    }
}

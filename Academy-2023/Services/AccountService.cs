using Academy_2023.Data;
using Academy_2023.Dto;
using Academy_2023.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace Academy_2023.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<User?> LoginAsync(LoginDto loginDto)
        {
            var user = await _userService.GetByEmailAsync(loginDto.Email);
            
            if (user == null || user.Password != EncryptPassword(loginDto.Password))
            {
                return null;
            }
            return user;
        }

        public string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hash = BitConverter.ToString(bytes).Replace("-", "");
                return hash;
            }
        }
    }
}

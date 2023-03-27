using Academy_2023.Data;
using Academy_2023.Services;
using System.Security.Cryptography;
using System.Text;

namespace Academy_2023.Repositories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAccountService _accountService;

        public UserService(IUserRepository userRepository, IAccountService accountService)
        {
            _userRepository = userRepository;
            _accountService = accountService;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _userRepository.GetAll();
            return users.Select(MapToDto);
        }

        public IEnumerable<UserDto> GetOlderThan(int age)
        {
            var users = _userRepository.GetOlderThan(age);
            return users.Select(MapToDto);
        }

        public UserDto? GetById(int id)
        {
            var user = _userRepository.GetById(id);
            return user == null ? null : MapToDto(user);
        }

        public void Create(UserDto userDto)
        {
            userDto.Password = _accountService.EncryptPassword(userDto.Password);
            _userRepository.Create(MapToEntity(userDto));
        }

        public User? Update(int id, UserDto data)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                user.Email = data.Email;
                user.Password = _accountService.EncryptPassword(data.Password);
                user.Name = data.Name;
                user.Age = data.Age;
                user.Role = data.Role;

                _userRepository.Update();
            }

            return user;
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public Task<User?> GetByEmailAsync(string email)
        {
            return _userRepository.GetByEmailAsync(email);
        }

        


        private UserDto MapToDto(User user) => new UserDto { Id = user.Id, Email = user.Email, Password = user.Password, Name = user.Name, Age = user.Age, Role = user.Role };

        private User MapToEntity(UserDto userDto) => new User { Id = userDto.Id, Email = userDto.Email, Password = userDto.Password, Name = userDto.Name, Age = userDto.Age, Role = userDto.Role };

    }
}

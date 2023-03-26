using Academy_2023.Data;
using System.Security.Cryptography;
using System.Text;

namespace Academy_2023.Repositories
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
            userDto.Password = EncryptPassword(userDto.Password);
            _userRepository.Create(MapToEntity(userDto));

        }

        public User? Update(int id, UserDto data)
        {
            var user = _userRepository.GetById(id);

            if (user != null)
            {
                user.Email = data.Email;
                user.Password = EncryptPassword(data.Password);
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

        private string EncryptPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
                string hash = BitConverter.ToString(bytes).Replace("-", "");
                return hash;
            }
        }


        private UserDto MapToDto(User user) => new UserDto { Id = user.Id, Email = user.Email, Password = user.Password, Name = user.Name, Age = user.Age, Role = user.Role };

        private User MapToEntity(UserDto userDto) => new User { Id = userDto.Id, Email = userDto.Email, Password = userDto.Password, Name = userDto.Name, Age = userDto.Age, Role = userDto.Role };

    }
}

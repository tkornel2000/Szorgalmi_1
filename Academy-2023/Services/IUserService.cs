using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public interface IUserService
    {
        void Create(UserDto userDto);
        bool Delete(int id);
        IEnumerable<UserDto> GetAll();
        UserDto? GetById(int id);
        IEnumerable<UserDto> GetOlderThan(int age);
        User? Update(int id, UserDto data);
        Task<User?> GetByEmailAsync(string email);
    }
}
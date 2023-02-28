using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class UserRepository
    {
        public static List<User> Users = new List<User>();

        public IEnumerable<User> GetAll()
        {
            return Users;
        }

        public User? GetById(int id)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }

            return null;
        }

        public void Create(User data)
        {
            Users.Add(data);
        }

        public User? Update(int id, User data)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    user.FirstName = data.FirstName;
                    user.LastName = data.LastName;

                    return user;
                }
            }

            return null;
        }

        public bool Delete(int id)
        {
            foreach (var user in Users)
            {
                if (user.Id == id)
                {
                    Users.Remove(user);

                    return true;
                }
            }

            return false;
        }
    }
}

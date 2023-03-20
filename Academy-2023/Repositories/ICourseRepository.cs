using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public interface ICourseRepository
    {
        void Create(Course data);
        Course? Delete(int id);
        IEnumerable<Course> GetAll();
        Course? GetById(int id);
        void Update();
    }
}
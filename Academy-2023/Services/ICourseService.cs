using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public interface ICourseService
    {
        void Create(CourseDto courseDto);
        Course? Delete(int id);
        IEnumerable<CourseDto> GetAll();
        CourseDto? GetById(int id);
        Course? Update(int id, CourseDto data);
    }
}
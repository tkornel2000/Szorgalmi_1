using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<CourseDto> GetAll()
        {
            var courses = _courseRepository.GetAll();
            return courses.Select(MapToDto);
        }

        public CourseDto? GetById(int id)
        {
            var course = _courseRepository.GetById(id);
            return course == null ? null : MapToDto(course);
        }

        public void Create(CourseDto courseDto)
        {
            _courseRepository.Create(MapToEntity(courseDto));
        }

        public Course? Update(int id, CourseDto data)
        {
            var course = _courseRepository.GetById(id);
            if (course != null)
            {
                course.Name = data.Name;
                course.Description = data.Description;
                course.Author = data.Author;
                _courseRepository.Update();

            }
            return course;
        }

        public Course? Delete(int id)
        {
            return _courseRepository.Delete(id);

        }
        private CourseDto MapToDto(Course course) => new CourseDto { Id = course.Id, Name = course.Name, Description = course.Description, Author = course.Author };

        private Course MapToEntity(CourseDto courseDto) => new Course { Id = courseDto.Id, Name = courseDto.Name, Description = courseDto.Description, Author = courseDto.Author };
    }
}

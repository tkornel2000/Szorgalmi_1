using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class CourseRepository
    {
        public static List<Course> Courses = new List<Course>();
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(x => x.id==id);
            if (course != null)
            {
                course.name = data.name;
                course.description = data.description;
                _context.SaveChanges();
                return data;
            }
            else
            {
                return null;
            }
        }

        public Course? Delete(int id)
        {
            var course = _context.Courses.FirstOrDefault(x => x.id == id);
            if (course != null)
            {
                _context.Remove(course);
                return course;
            }

            return null;
        }
    }
}

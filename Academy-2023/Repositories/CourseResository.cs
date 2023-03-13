using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class CourseRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course? GetById(int id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);
        }

        public void Create(Course data)
        {
            _context.Courses.Add(data);
            _context.SaveChanges();
        }

        public Course? Update(int id, Course data)
        {
            var course = _context.Courses.FirstOrDefault(x => x.Id==id);
            if (course != null)
            {
                course.Name = data.Name;
                course.Description = data.Description;
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
            var course = _context.Courses.FirstOrDefault(x => x.Id == id);
            if (course != null)
            {
                _context.Remove(course);
                return course;
            }

            return null;
        }
    }
}

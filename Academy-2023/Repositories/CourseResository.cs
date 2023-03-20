using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;

        public CourseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

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

        public void Update()
        {
            _context.SaveChanges();
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

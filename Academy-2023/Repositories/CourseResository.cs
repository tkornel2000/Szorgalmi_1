using Academy_2023.Data;

namespace Academy_2023.Repositories
{
    public class CourseRepository
    {
        public static List<Course> Courses = new List<Course>();

        public IEnumerable<Course> GetAll()
        {
            return Courses;
        }

        public Course? GetById(int id)
        {
            foreach (var course in Courses)
            {
                if (course.id == id)
                {
                    return course;
                }
            }

            return null;
        }

        public void Create(Course data)
        {
            Courses.Add(data);
        }

        public Course? Update(int id, Course data)
        {
            foreach (var course in Courses)
            {
                if (course.id == id)
                {
                    course.name = data.name;
                    course.description = data.description;

                    return course;
                }
            }

            return null;
        }

        public bool Delete(int id)
        {
            foreach (var course in Courses)
            {
                if (course.id == id)
                {
                    Courses.Remove(course);

                    return true;
                }
            }

            return false;
        }
    }
}

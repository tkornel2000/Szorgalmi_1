using Academy_2023.Data;
using Academy_2023.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }




        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<CourseDto> Get()
        {
            return _courseService.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<CourseDto> Get(int id)
        {
            var course = _courseService.GetById(id);

            return course == null ? NotFound() : course;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] CourseDto data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _courseService.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] CourseDto data)
        {
            var course = _courseService.Update(id, data);

            return course == null ? NotFound() : Ok(data);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var course = _courseService.Delete(id);
            return course != null ? Ok(course) : NotFound();
        }
    }
}

using Academy_2023.Data;
using Academy_2023.Repositories;
using Microsoft.AspNetCore.Mvc;
using Xceed.Wpf.Toolkit;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Academy_2023.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }



        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet("getOlderThan")]
        public IEnumerable<UserDto> GetOlderThan([FromQuery] int age)
        {
            return _userService.GetOlderThan(age);
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> Get(int id)
        {
            var user = _userService.GetById(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] UserDto data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userService.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserDto data)
        {
            var user = _userService.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _userService.Delete(id) ? NoContent() : NotFound();
        }
    }
}

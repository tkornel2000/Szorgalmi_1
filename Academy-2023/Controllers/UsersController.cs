﻿using Academy_2023.Data;
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
        private UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = new UserRepository();
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userRepository.GetAll();
        }

        [HttpGet("getOlderThan")]
        public IEnumerable<User> GetOlderThan([FromQuery] int age)
        {
            return _userRepository.GetOlderThan(age);
        }


        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userRepository.GetById(id);

            return user == null ? NotFound() : user;
        }

        // POST api/<UsersController>
        [HttpPost]
        public ActionResult Post([FromBody] User data)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userRepository.Create(data);

            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User data)
        {
            var user = _userRepository.Update(id, data);

            return user == null ? NotFound() : NoContent();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return _userRepository.Delete(id) ? NoContent() : NotFound();
        }
    }
}

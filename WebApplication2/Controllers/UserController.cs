using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication2.Data;
using WebApplication2.Dto;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("/api/v1.0/user")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] UserDto userDto)
        {
            if (ModelState.IsValid)
            {
                var user = userDto.ToModel();
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = _context.Users.ToList();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] UserDto userDto)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                ModelState.AddModelError("UserId", "Id do usuário não encontrado!");
                return BadRequest(ModelState);
            }

            if (ModelState.IsValid)
            {
                user.Username = userDto.Username;
                user.Email = userDto.Email;
                _context.Users.Update(user);
                _context.SaveChanges();
                return user;
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                ModelState.AddModelError("UserId", "Id do usuário não encontrado!");
                return BadRequest(ModelState);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullStack.Models;
using FullStack.Data;
using Microsoft.EntityFrameworkCore;
using BackEnd.DTO;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _db { get; set; }

        public UserController(DataContext datacontext)
        {
            _db = datacontext;
        }
        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return _db.users;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            return _db.users.FirstOrDefault(x => x.id == id);
        }
        [HttpPost]
        public void Post(User user)
        {
            _db.users.Add(user);
            _db.SaveChanges();
        }

        [HttpPost("login")]
        public ActionResult<bool> login(LoginDTO dto)
        {
            var user = _db.users.FirstOrDefault(x =>
            x.email == dto.email
            && x.password == dto.password);

            if (user != null)
                return Ok(true);

            return BadRequest(false);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, User user)
        {
            var value = _db.users.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (value != null)
            {
                _db.users.Update(user);
                _db.SaveChanges();
                return Ok(user);
            }
            else
            {
                return BadRequest("Invalid Id");
            }
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var value = _db.users.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (value != null)
            {
                _db.users.Remove(value);
                _db.SaveChanges();
                return Ok("SuccessFully Deleted");
            }
            else
            {
                return BadRequest("Invalid Id");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FullStack.Models;
using FullStack.Data;
using BackEnd.Helpers;
using Microsoft.EntityFrameworkCore;
using BackEnd.DTO;
using BackEnd.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private DataContext _db { get; set; }
        private IJWTmanager _jwt;
        private PasswordManager _passwordManager;

        public UserController(DataContext datacontext, IJWTmanager jwt)
        {
            _jwt = jwt;
            _passwordManager = new PasswordManager();
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

        [HttpPost("register")]
        public IActionResult Register(RegisterDTO user)
        {
            var userExists = _db.users.FirstOrDefault(x =>
            x.email == user.email);
            if (userExists != null)
            {
                return BadRequest("User Already Exists");
            }

            byte[] passwordHash;
            byte[] passwordSalt;
            _passwordManager.CreatePasswordHash(user.password, out passwordHash, out passwordSalt);

            User newUser = new User
            {
                email = user.email,
                passwordHash = passwordHash,
                passwordSalt = passwordSalt,
                name = user.name,
                nationalId = user.nationalId
            };
            _db.users.Add(newUser);
            _db.SaveChanges();

            return Ok(new { message = "User Created" });
        }

        [HttpPost("login")]
        public IActionResult login(LoginDTO dto)
        {
            var user = _db.users.FirstOrDefault(x =>
            x.email == dto.email);
            if (user == null)
            {
                return BadRequest("User doesn't exist");
            }

            bool verify = _passwordManager.VerifyPasswordHash(dto.password, user.passwordHash, user.passwordSalt);

            if (verify)
            {
                var token = _jwt.GenerateJwtToken(user);
                return Ok(new { token = token });
            }

            /*
            
            eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiTXVoYW1tYWQgRmFpcXVlIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvZW1haWxhZGRyZXNzIjoibXVoYW1tYWRmYWlxdWU3QGdtYWlsLmNvbSIsIm5iZiI6MTU2OTc0NzAwNSwiZXhwIjoxNTcyMzM5MDA1fQ.bDFJ8hWIq1hTo_VP5qIrZIHL371mREdYVfe0b9wNSKexmoH7cV_VfdyygMaXamuc8lUenJPqshWvQ514YeJntQ

             */

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
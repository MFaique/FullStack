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
    public class UserAddressController : ControllerBase
    {
        private DataContext _db { get; set; }

        public UserAddressController(DataContext datacontext)
        {
            _db = datacontext;
        }
        // GET api/user
        [HttpGet]
        public ActionResult<IEnumerable<UserAddress>> Get()
        {
            return _db.userAddresses;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<UserAddress> Get(int id)
        {
            return _db.userAddresses.FirstOrDefault(x => x.id == id);
        }

        [HttpGet("GetByUserId/{userId}")]
        public ActionResult<UserAddress> GetByUserId(int userId)
        {
            return _db.userAddresses.FirstOrDefault(x => x.id == userId);
        }

        [HttpPost]
        public void Post(UserAddress userAddress)
        {
            _db.userAddresses.Add(userAddress);
            _db.SaveChanges();
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult<UserAddress> Put(int id, UserAddress userAddress)
        {
            var value = _db.userAddresses.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (value != null)
            {
                _db.userAddresses.Update(userAddress);
                _db.SaveChanges();
                return Ok(userAddress);
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
            var value = _db.userAddresses.AsNoTracking().FirstOrDefault(x => x.id == id);
            if (value != null)
            {
                _db.userAddresses.Remove(value);
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RegisterLoging.Models;

namespace RegisterLoging.Controllers
{
    [Route("android-api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static MyDatabase db = new MyDatabase();
        public UsersController()
        {
            if(db.People.Count() == 0)
            {
                db.People.AddRange(
                    new Person {
                        Name = "Amir",
                        Username = "amir_01",
                        Password = "test1"
                    },
                    new Person {
                        Name = "Ali",
                        Username = "ali_the_hacker",
                        Password = "test2"
                    },
                    new Person {
                        Name = "Sajad",
                        Username = "sajjad99",
                        Password = "test3"
                    },
                    new Person {
                        Name = "Hashem",
                        Username = "h4shem",
                        Password = "test4"
                    }
                );
                db.SaveChanges();
            }
        }

        // GET android-api/users/get-all-users
        [HttpGet("Get-All-Users")]
        public ActionResult GetAllUsers()
        {
            try
            {
                if(db.People.Count() != 0) return Ok(new { Users = db.People.ToArray() });
            }
            catch
            {
                return BadRequest(new Response { Success = false, Message = "DATABASE_ERROR" });
            }
            return BadRequest(new Response { Success = false, Message = "DATABASE_IS_EMPTY" });
        }

        // GET android-api/users/get-profile?username=ali
        [HttpGet("Get-Profile")]
        public ActionResult GetProfile(string username)
        {
            try
            {
                var result = db.People.Where(q => q.Username == username).FirstOrDefault();
                if(result != null) return Ok(new { User = result });
            }
            catch
            {
                return BadRequest(new Response { Success = false, Message = "DATABASE_ERROR" });
            }
            return BadRequest(new Response { Success = false, Message = "USERNAME_DOES_NOT_EXIST" });
        }

        // POST android-api/users/validate
        [HttpPost("Validate")]
        public ActionResult<Response> Validate([FromBody] string[] pair)
        {
            try
            {
                var result = db.People.Where(q => q.Username == pair[0] && q.Password == pair[1]).FirstOrDefault();
                if(result != null) return Ok(new Response { Success = true });
            }
            catch
            {
                return BadRequest(new Response { Success = false, Message = "DATABASE_ERROR" });
            }
            return BadRequest(new Response { Success = false, Message = "LOGIN_IS_INVALID" });
        }

        // POST android-api/users/register
        [HttpPost("Register")]
        public ActionResult Register([FromBody] Person person)
        {
            try
            {
                var duplicate = db.People.Where(q => q.Username == person.Username).FirstOrDefault();
                if(duplicate == null)
                {
                    db.People.Add(person);
                    db.SaveChanges();
                }
                else
                {
                    return BadRequest(new Response { Success = false, Message = "USERNAME_ALREADY_EXISTS" });
                }
            }
            catch
            {
                return BadRequest(new Response { Success = false, Message = "DATABASE_ERROR" });
            }
            return Ok(new Response { Success = true });
        }
    }
}

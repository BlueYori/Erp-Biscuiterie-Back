using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Erp_Biscuiterie_Back.Business.Context;
using Erp_Biscuiterie_Back.Business.Models;
using Erp_Biscuiterie_Back.Utils.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Erp_Biscuiterie_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public UserController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            /*var userList = await (from user in _context.User
                                  join role in _context.Role on user.RoleId equals role.Id into tmp
                                  from m in tmp.DefaultIfEmpty()

                                  select new User
                                  {
                                      Id = user.Id,
                                      Firstname = user.Firstname,
                                      Lastname = user.Lastname,
                                      Email = user.Email,
                                      Password = user.Password,
                                      RoleId = m.Id,
                                      Role = m
                                 }
                      ).ToListAsync();
            return userList;*/
            //var userList = await _context.User.ToListAsync();
            var userList = await _context.User.Include(user => user.Role).ToListAsync();
            return userList;
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // Doc microsoft
            var user = await _context.User.Include(u => u.Role).FirstOrDefaultAsync(u => u.Id == id);

            /*
             * LINQ Query expressions
             */

            //var user = await (from p in _context.User
            //                    where p.Id == id
            //                    select p).FirstAsync();

            /*
             * SQL Equivalent
             * SELECT * FROM user WHERE user.Id == 2
             */

            /*
             * LINQ Method
             */

            //var user = await _context.User.Where(c => c.Id == id).FirstAsync();

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Get api/user/JoinRole
        [Route("joinRole")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUserJoinRole()
        {
            var user = await _context.User.ToListAsync();

            var join = (from p in _context.User
                        join r in _context.Role
                        on p.RoleId equals r.Id
                        select new User
                        {
                            Id = p.Id,
                            Firstname = p.Firstname,
                            Lastname = p.Lastname,
                            RoleId = r.Id,
                            Role = r
                        }).ToList();

            if (join == null)
            {
                return NotFound();
            }

            return join;
        }

        // POST api/user
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            user.Password = Crypto.EncryptPassword(user.Password.ToString());
            _context.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        
        // talk maybe one controller for signin and signup
        [HttpPost("sign-in")]
        public ActionResult<User> SignIn([FromBody] Credentials Credentials)
        {
            
            if (ModelState.IsValid)
            {
                var user = _context.User.SingleOrDefault(x => x.Email == Credentials.Email);

                if (user == null)
                {
                    return Unauthorized();
                }

                if (Crypto.EncryptPassword(Credentials.Password) != user.Password)
                {
                    return Unauthorized();
                }

                // write token in hheader
                Crypto.getToken(user.RoleId);
                return user;
            }

            return null;
        }

    }
}

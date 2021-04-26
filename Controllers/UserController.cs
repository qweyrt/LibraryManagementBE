using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Models;
using LibraryManagement.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        LibraryManagementDbContext _context;
        public UserController(IUserService userService, LibraryManagementDbContext context)
        {
            _userService = userService;
            _context = context;
        }
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public ActionResult<IEnumerable<UserModel>> Get()
        {
            return _userService.GetAll();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<UserModel> Get(int id)
        {
            return _userService.GetById(id);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Post(UserModel user)
        {
            if (_userService.Create(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Put(int id, UserModel user)
        {
            id = user.UserId;
            if (_userService.Update(user))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            if (_userService.Delete(id))
            {
                return Ok();
            }
            return BadRequest();
        }
        [HttpPost("login")]
        public IActionResult Login(Login user)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            var result = _context.Users.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();
            if (result != null)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name,_context.Users
                                                      .Where(x=>x.Username ==user.Username && x.Password == user.Password)
                                                      .Single().Username),
                    new Claim(ClaimTypes.Role,_context.Users
                                                      .Where(x=>x.Username ==user.Username && x.Password == user.Password)
                                                      .Single().Role.ToString())

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthenticate = true;
                // HttpContext.Session.SetString("userId",user.UserId.ToString());
            }
            if (isAuthenticate)
            {
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Ok();
            }
            return BadRequest();

        }
        [HttpPost("logout")]

        public async System.Threading.Tasks.Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            //HttpContext.Session.Remove("userId");
            return Ok();
        }
    }
}

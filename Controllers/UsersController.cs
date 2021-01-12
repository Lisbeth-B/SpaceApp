using Microsoft.AspNetCore.Mvc;
using System;
using SpaceApp.Entity;
using SpaceApp.Models;

namespace SpaceApp.Controllers
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

        // POST: api/Users/register
        [HttpPost("register")]
        public IActionResult Create([FromBody] RegisterModel model)
        {
            try
            {
                _userService.Register(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // POST: api/Users/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            try
            {
                User user = _userService.Login(model);

                if (user == null)
                {
                    return BadRequest(new { message = "Username or password is incorrect" });
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Users/IsMarried
        [HttpPut("IsMarried")]
        public IActionResult PutUserIsMarried([FromBody] UpdateIsMarriedModel model)
        {
            try
            {
                _userService.UpdateIsMarried(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        }

        // PUT: api/Users/IsWorker
        [HttpPut("IsWorker")]
        public IActionResult PutUserIsWorker([FromBody] UpdateIsWorkerModel model)
        {
            try
            {
                _userService.UpdateIsWorker(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // PUT: api/Users/Address
        [HttpPut("Address")]
        public IActionResult PutUserAddress([FromBody] UpdateAddressModel model)
        {
            try
            {
                _userService.UpdateAddress(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}

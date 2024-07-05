using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BankLoanManagement.Models;
using BankLoanManagement.Services.Interface;
using BankLoanManagement.Models.DTO;
using NuGet.Protocol.Plugins;
using Microsoft.AspNetCore.Identity;

namespace BankLoanManagement.Controllers
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

        [HttpPost("authentication")]
        public async Task<IActionResult> Authenticate([FromBody]UserDto.UserLoginDto userLoginDto)
        {
            var user = await _userService.Authenticate(userLoginDto.Username, userLoginDto.PasswordHash);
            if (user == null)
            {
                return BadRequest(new { messege = "username or pwd is incorrect" });
            }
            return Ok(user);

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto.UserRegisterDto userRegisterDto)
        {
            var user=new User { Username=userRegisterDto.Username};
            try
            {
                await _userService.Register(user, userRegisterDto.PasswordHash);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new {Message = ex.Message});
            }

        }


    }
}

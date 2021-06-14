using BLL.Interfaces;
using BLL.Models;
using EpamFinal;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Final.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ApplicationSettings _appSettings;
        public ApplicationUserController(IUserService userService, IOptions<ApplicationSettings> applicationSettings)
        {
            _appSettings = applicationSettings.Value;
            _userService = userService;
        }

        [HttpPost]
        [Route("Registration")]
        //POST : /ApplicationUser/Registration
        public async Task<Object> PostApplicationUser(UserModel model)
        {
            try
            {
                if (_userService.CheckValidation(model))
                {
                    var res = await _userService.AddAsync(model);
                    return Ok(new { succeeded = true  });
                }
                return new { succeeded = false };

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [HttpPost]
        [Route("Login")]
        //POST : /ApplicationUser/Login
        public IActionResult Login(AuthModel model)
        {
            var user = _userService.GetByUserName(model.UserName);

            if (user != null && _userService.CheckPassword(user.UserName, model.Password))
            {
                var role = user.Role;
                IdentityOptions identityOptions = new IdentityOptions();
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", GetUserId(user).ToString()),
                        new Claim(identityOptions.ClaimsIdentity.RoleClaimType, role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
                return BadRequest(new { message = "Username or password is incorrect." });
        }

        [HttpGet]
        [Authorize]
        //GET : /ApplicationUser
        public IActionResult GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserID").Value;
            var user = _userService.GetByGuid(userId);
            return Ok(user);
        }
        private string GetUserId(UserModel user)
        {
            return _userService.GetUserGuid(user);
        }
    }
}

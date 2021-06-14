using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpamFinal.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("AllUsers")]
        public IActionResult GetAllUsers()
        {
            var userNames = _userService.GetAll().Select(user => user.UserName);
            return Ok(userNames);
        }
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser([FromQuery] string userName)
        {
            var userToDelete = _userService.GetByUserName(userName);
            string userGuid = _userService.GetUserGuid(userToDelete);
            _userService.DeleteByIdAsync(userGuid);
            return Ok();
        }

    }
}

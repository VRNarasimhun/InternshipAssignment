using InternUserManagement.Models.DTO;
using InterUserManagementAPI.Interfaces;
using InterUserManagementAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterUserManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IManageUser _manageUser;

        public UserController(IManageUser manageUser)
        {
            _manageUser = manageUser;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Register(InternDTO intern)
        {
            var result = await _manageUser.Register(intern);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Unable to register at this moment");

        }
        //[HttpPost]
        //public ActionResult<UserDTO> Login([FromBody] UserDTO userDTO)
        //{
        //    var user = _manageUser.Login(userDTO);
        //    if (user == null)
        //    {
        //        return BadRequest("Invalid username or password");
        //    }
        //    return Ok(user);
        //}

    }
}
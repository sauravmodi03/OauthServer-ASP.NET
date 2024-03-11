using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationServer.Services;
using AuthServer.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CORSOpenPolicy")]
    public class RegisterController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;

        public RegisterController(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }


        [HttpPost("user")]
        public IActionResult RegisterUser([FromBody] UserDto userDto)
        {
            AuthResponseDto response =  authenticationService.Register(userDto);
            return Ok(response);
        }
    }
}


using AuthenticationServer.Services;
using AuthServer.Dto;
using AuthServer.Models;
using AuthServer.Utility;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CORSOpenPolicy")]
    public class LoginController : ControllerBase
    {

        private readonly IAuthenticationService service;
        private readonly IConfiguration config;

        public LoginController(IAuthenticationService _service, IConfiguration _config)
        {
            service = _service;
            config = _config;
        }
    

        [HttpPost("basic")]
        public IActionResult Login()
        {
            bool isAuthPresent = Request.Headers.TryGetValue("Authorization", out var credentials);
            if(isAuthPresent)
            {
                AuthResponseDto responseDto =  service.Login(credentials[0]!);

                return Ok(responseDto);
                
            }
            return Ok(new AuthResponseDto("", "", "Authorization missing."));
        }
    }
}


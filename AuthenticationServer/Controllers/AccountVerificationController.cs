using AuthenticationServer.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class AccountVerificationController : ControllerBase
    {

        private IAuthenticationService authentication;

        public AccountVerificationController(IAuthenticationService _service)
        {
            authentication = _service;
        }

        [HttpGet("{apiname}", Name ="verifyaccount")]
        public IActionResult VerifyAccount(string token)
        {
            authentication.VerifyAccount(token);
            return Ok();
        }
    }
}


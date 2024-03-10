using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthenticationServer.Models;
using AuthenticationServer.Services;
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

    

        [HttpPost("apiname", Name = "login")]
        public IActionResult Login()
        {
            var request = Request;
            Console.WriteLine(request.Headers);
            //AuthenticationModel model = new AuthenticationModel("","");
            //if (service.Login(model))
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            return Ok();
        }
    }
}


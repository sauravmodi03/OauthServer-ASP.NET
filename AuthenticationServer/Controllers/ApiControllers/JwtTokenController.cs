using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Models;
using AuthServer.Services.JwtTokenService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CORSOpenPolicy")]
    public class JwtTokenController : ControllerBase
    {

        private readonly JwtService jwtService;

        public JwtTokenController(JwtService jwtService)
        {
            this.jwtService = jwtService;
        }


        [HttpGet("get/active/tokens")]
        public List<JwtToken> GetAccessTokensByEmail(string email)
        {
            return jwtService.GetTokensByEmail(email);
        }

        [HttpGet("get/active/token")]
        public IActionResult GetAccessTokenByEmail(string email)
        {
            return Ok(jwtService.GetActiveTokenByEmail(email));
        }
    }
}


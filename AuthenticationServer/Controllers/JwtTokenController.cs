using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Models;
using AuthServer.Services.JwtTokenService;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthServer.Controllers
{
    [ApiController]
    [Route("api[controller]")]
    public class JwtTokenController : ControllerBase
    {

        private readonly JwtService jwtService;

        public JwtTokenController(JwtService jwtService)
        {
            this.jwtService = jwtService;
        }


        [HttpGet("apiname", Name ="get/active/token")]
        public List<JwtToken> GetAccessTokenByEmail(string email, HttpClient httpClient)
        {
            return jwtService.GetTokensByEmail(email);
            //return OkObjectResult(tokens);
        }
    }
}


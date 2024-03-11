using Microsoft.AspNetCore.Mvc;
using AuthenticationServer.Models;
using AuthenticationServer.Services;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthenticationServer.Controllers
{
    
    public class AuthenticationController : Controller
    {

        //private readonly UserDataContext context;
        private readonly IAuthenticationService service;
        private readonly IConfiguration config;

        public AuthenticationController(IAuthenticationService _service, IConfiguration _config)
        {
            service = _service;
            config = _config;
        }

        
        public IActionResult Login()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Login(AuthenticationModel model)
        //{
        //    if (service.Login(model))
        //    {
        //        return RedirectToAction("Index","Home");
        //    }
        //    return RedirectToAction("Fail");
        //}

       
        //public IActionResult Register(AuthenticationModel model)
        //{
        //    if (service.Register(model))
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return RedirectToAction("Fail");
        //}

        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Fail()
        {
            return View();
        }

    }
}


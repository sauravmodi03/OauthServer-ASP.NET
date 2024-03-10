
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceServer.Controllers
{
    [ApiController]
    [Route("api")]
    public class ResourceController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("apiname", Name ="get/data")]
        public void GetData(HttpClient httpClient)
        {

        }
    }
}


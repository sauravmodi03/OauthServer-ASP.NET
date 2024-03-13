
using System.Net;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ResourceServer.Dto;
using ResourceServer.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ResourceServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("CORSOpenPolicy")]
    public class ResourceController : ControllerBase
    {
        private readonly ITodoService todoService;
        private readonly AuthorizationService authService;

        public ResourceController(ITodoService todoService, AuthorizationService authorization)
        {
            this.todoService = todoService;
            this.authService = authorization;
        }

        [HttpGet("get/todos")]
        public IActionResult GetTodos(string email)
        {
            if (ValidateRequest())
            {
                return Ok(todoService.GetAllTodo(email));
            }

            return Unauthorized("Authorization missing or Invalid.");
        }

        [HttpPost("add/todo")]
        public IActionResult AddTodo([FromBody] TodoDto dto)
        {
            if (ValidateRequest())
            {
                return Ok(todoService.AddTodo(dto));
            }

            return Unauthorized("Authorization missing or Invalid.");
        }

        [HttpPost("update/todo")]
        public IActionResult UpdateTodo([FromBody] TodoDto dto)
        {
            if (ValidateRequest())
            {
                todoService.UpdateTodo(dto);
                return Ok();
            }

            return Unauthorized("Authorization missing or Invalid.");
        }

        [HttpGet("delete/todo")]
        public IActionResult UpdateTodo(int id)
        {
            if (ValidateRequest())
            {
                todoService.DeleteTodo(id);
                return Ok();
            }

            return Unauthorized("Authorization missing or Invalid.");
        }

        private bool ValidateRequest()
        {
            bool auth = Request.Headers.TryGetValue("Authorization", out var accessToken);
            return auth && authService.ValidateAccesToken(accessToken);
        }
    }
}


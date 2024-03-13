using System;
namespace ResourceServer.Dto
{
	public class TodoResponse
	{
		public string Email { get; set; }
		public List<TodoDto> Todos { get; set; }

		public TodoResponse(string email, List<TodoDto> todos)
		{
			Email = email;
			Todos = todos;
		}
	}
}


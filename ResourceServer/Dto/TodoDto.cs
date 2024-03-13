using System;
using ResourceServer.Entity;

namespace ResourceServer.Dto
{
	public class TodoDto
	{
        public int Id { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; } = false;

        public TodoDto()
        {

        }

        public TodoDto(Todo todo)
		{
            Id = todo.Id;
            Email = todo.Email;
            Title = todo.Title;
            Description = todo.Description;
            Completed = todo.Completed;
		}
	}
}


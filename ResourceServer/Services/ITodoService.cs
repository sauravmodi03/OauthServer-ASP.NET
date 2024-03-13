using System;
using ResourceServer.Dto;

namespace ResourceServer.Services
{
	public interface ITodoService
	{

		public TodoResponse GetAllTodo(string email);

		public TodoDto AddTodo(TodoDto dto);

		public void DeleteTodo(int id);

		public void UpdateTodo(TodoDto todo);
	}
}


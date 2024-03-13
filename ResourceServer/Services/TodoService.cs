using System;
using ResourceServer.Dto;
using ResourceServer.Entity;
using ResourceServer.Repository;

namespace ResourceServer.Services
{
	public class TodoService : ITodoService
	{

        private readonly TodoRepository todoRepository;
        private readonly AuthorizationService authService;

		public TodoService(TodoRepository _todoRepository, AuthorizationService _auth)
		{
            todoRepository = _todoRepository;
            authService = _auth;
		}

        public TodoDto AddTodo(TodoDto dto)
        {
            var entity =  todoRepository.AddTodo(new Todo(dto));
            return new TodoDto(entity);
        }

        public void DeleteTodo(int id)
        {
            todoRepository.DeleteTodo(id);
        }

        public TodoResponse GetAllTodo(string email)
        {
            List<TodoDto> todos = new List<TodoDto>();
            foreach( var todo in todoRepository.GetAllTodo(email))
            {
                todos.Add(new TodoDto(todo));
            }
            return new TodoResponse(email,todos);
        }

        public void UpdateTodo(TodoDto todo)
        {
            Todo entity = new Todo(todo);
            todoRepository.UpdateTodo(entity);
        }

         
    }
}


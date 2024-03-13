using System;
using Microsoft.EntityFrameworkCore;
using ResourceServer.Dto;
using ResourceServer.Entity;

namespace ResourceServer.Repository
{
	public class TodoRepository
	{
		private readonly DbContext dbContext;

        public TodoRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Todo GetById(int id)
        {
            return dbContext.Set<Todo>().Find(id)!;
        }

        public Todo AddTodo(Todo todo)
        {
            var entityEntry = dbContext.Set<Todo>().Add(todo);
            dbContext.SaveChanges();
            return entityEntry.Entity;
        }

        public void DeleteTodo(int id)
        {
            dbContext.Set<Todo>().Remove(GetById(id));
            dbContext.SaveChanges();
        }

        public List<Todo> GetAllTodo(string email)
        {
            return dbContext.Set<Todo>().Where(t => t.Email.Equals(email)).ToList();
        }

        public void UpdateTodo(Todo todo)
        {
            dbContext.Set<Todo>().Update(todo);
            dbContext.SaveChanges();
        }
    }
}


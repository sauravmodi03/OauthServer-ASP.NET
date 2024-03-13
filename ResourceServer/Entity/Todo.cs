using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ResourceServer.Dto;

namespace ResourceServer.Entity
{
	public class Todo
	{
        

        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public string Email { get; set;}
		public string Title { get; set; }
		public string Description { get; set; }
		public bool Completed { get; set; }

        public Todo()
        { }

        public Todo(TodoDto dto)
        {
            Email = dto.Email;
            Title = dto.Title;
            Description = dto.Description;
            Completed = dto.Completed;
        }

        public Todo(string email, string title, string description, bool completed)
        {
            Email = email;
            Title = title;
            Description = description;
            Completed = completed;
        }
    }
}


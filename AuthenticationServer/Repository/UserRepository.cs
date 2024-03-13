using System;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Services
{
	public class UserRepository : IRepository<User>
	{
        private readonly DbContext context;

        public UserRepository(DbContext _context)
		{
			context = _context;
		}

        public void Add(User user)
        {
            context.Set<User>().Add(user);
            context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Set<User>().ToList();
        }

        public User GetByEmail(string Email)
        {
            return context.Set<User>().First(u => u.Email!.Equals(Email));
        }

        public void ValidateUserByAccount(string Email)
        {
            var entity = GetByEmail(Email);
            entity.EmailVerified = true;
            context.SaveChanges();
        }

        public bool CheckUserExists(string email)
        {
            return context.Set<User>().Any(u => u.Email!.Equals(email));
        }

    }
}


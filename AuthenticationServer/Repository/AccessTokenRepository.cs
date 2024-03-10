using System;
using AuthenticationServer.Services;
using AuthServer.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Repository
{
	public class AccessTokenRepository : IRepository<AccessToken>
	{
        private readonly DbContext context;

		public AccessTokenRepository(DbContext _context)
		{
            context = _context;
		}

        public void Add(AccessToken t)
        {
            context.Set<AccessToken>().Add(t);
            context.SaveChanges();
        }

        public IEnumerable<AccessToken> GetAll()
        {
            return context.Set<AccessToken>().ToList();
        }

        public AccessToken GetByEmail(string Email)
        {
            return context.Set<AccessToken>().First(t => t.Email.Equals(Email) && t.TokenValid);
        }

        public IEnumerable<AccessToken> GetAllByEmail(string Email)
        {
            return context.Set<AccessToken>().Where(t => t.Email.Equals(Email));
        }
    }
}


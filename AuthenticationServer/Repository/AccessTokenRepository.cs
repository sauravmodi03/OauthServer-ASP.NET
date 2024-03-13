using System;
using AuthenticationServer.Services;
using AuthServer.Entity;
using Microsoft.EntityFrameworkCore;

namespace AuthServer.Repository
{
	public class AccessTokenRepository
	{
        private readonly DbContext context;

		public AccessTokenRepository(DbContext _context)
		{
            context = _context;
		}

        public void Add(AccessToken t)
        {
            InvalidateOldToken(t.Email);
            context.Set<AccessToken>().Add(t);
            context.SaveChanges();
        }

        public IEnumerable<AccessToken> GetAll()
        {
            return context.Set<AccessToken>().ToList();
        }

        public AccessToken? GetActiveTokenByEmail(string Email)
        {
            if(context.Set<AccessToken>().Any(t => t.Email.Equals(Email)))
            {
                return context.Set<AccessToken>().First(t => t.Email.Equals(Email) && t.TokenValid);
            }
            return null;
        }

        public IEnumerable<AccessToken> GetAllByEmail(string Email)
        {
            return context.Set<AccessToken>().Where(t => t.Email.Equals(Email));
        }

        private void InvalidateOldToken(string email)
        {
            var entity = GetActiveTokenByEmail(email);
            if(entity != null)
            {
                entity.TokenValid = false;
                context.Update(entity);
                context.SaveChanges();
            }
        }
    }
}


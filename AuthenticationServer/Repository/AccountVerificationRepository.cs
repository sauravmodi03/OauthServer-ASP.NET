using System;
using AuthenticationServer.Models;
using AuthenticationServer.Services;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServer.Repository
{
	public class AccountVerificationRepository : IRepository<AccountVerification>
	{
        private readonly DbContext context;
        private readonly UserRepository userRepository;

        public AccountVerificationRepository(DbContext _context, UserRepository _repository)
		{
            context = _context;
            userRepository = _repository;
		}

        public void Add(AccountVerification token)
        {
            context.Set<AccountVerification>().Add(token);
            context.SaveChanges();
        }

        public IEnumerable<AccountVerification> GetAll()
        {
            return context.Set<AccountVerification>().ToList();
        }

        public AccountVerification GetByEmail(string Email)
        {
           return context.Set<AccountVerification>().First(t => t.Email.Equals(Email));
        }

        public AccountVerification GetActiveTokenByEmail(string Email)
        {
            return context.Set<AccountVerification>().First(t => t.Email.Equals(Email) && t.TokenValid);
        }

        public void UpdateTokenStatusByEmail(string Email)
        {
            var entity = GetActiveTokenByEmail(Email);
            entity.TokenValid = false;
            context.SaveChanges();
        }
    }
}


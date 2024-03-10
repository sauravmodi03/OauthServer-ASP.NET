using System;
namespace AuthenticationServer.Services
{
	public interface IRepository<T>
	{
		IEnumerable<T> GetAll();
		T GetByEmail(string Email);
		void Add(T t);
	}
}


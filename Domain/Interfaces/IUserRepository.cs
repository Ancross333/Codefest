using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
	public interface IUserRepository
	{
		Task AddAsync(User.User user);
		Task SaveChangesAsync();
		Task<User.User?> GetAsync(int id);
	}
}

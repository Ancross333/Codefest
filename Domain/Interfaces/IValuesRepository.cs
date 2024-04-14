using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Values;

namespace Domain.Interfaces
{
	public interface IValuesRepository
	{
		Task AddAsync(List<Interest> values, int userId);
		Task SaveChangesAsync();
		List<Interest> GetValues(int userId);
	}
}

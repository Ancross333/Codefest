﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Domain;
using Domain.User;

namespace Domain.Interfaces
{
	public interface IUserRepository
	{
		Task AddAsync(User.User user);
		Task SaveChangesAsync();

		Task<User.User> GetAsync(string email, string password);
		Task UpdateAsync(string email, string companyName, string firstName, string lastName, Zip zip, AccountType accountType, ProfilePicture profilePicture);
	}
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteTaking.Models;

namespace NoteTaking.Service.Contracts
{
	public interface IUserService
	{
		Task<List<User>> GetAllAsync();

		Task<User> GetAsync(Guid id);

		Task<User> CreateAsync(User user);

		Task UpdateAsync(User user);

		Task DeleteAsync(Guid id);
	}
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteTaking.Models;

namespace NoteTaking.Service.Contracts
{
	public interface IUserService
	{
		List<User> GetAll();

		Task<User> Get(Guid id);

		Task<User> CreateAsync(User user);
	}
}
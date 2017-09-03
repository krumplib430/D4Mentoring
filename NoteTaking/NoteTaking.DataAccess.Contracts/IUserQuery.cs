using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.Contracts
{
	public interface IUserQuery
	{
		Task<List<User>> GetAllAsync();

		Task<User> GetAsync(Guid id);
	}
}
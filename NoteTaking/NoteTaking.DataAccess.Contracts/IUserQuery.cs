using System;
using System.Collections.Generic;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.Contracts
{
	public interface IUserQuery
	{
		List<User> GetAll();

		User Get(Guid id);
	}
}
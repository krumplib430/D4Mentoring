using System;
using System.Collections.Generic;
using NoteTaking.Models;

namespace NoteTaking.Service.Contracts
{
	public interface IUserService
	{
		List<User> GetAll();

		User Get(Guid id);

		User Create(User user);
	}
}
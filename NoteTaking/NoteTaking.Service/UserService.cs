using System;
using System.Collections.Generic;
using NoteTaking.Models;
using NoteTaking.Service.Contracts;

namespace NoteTaking.Service
{
	public class UserService : IUserService
	{
		/// <inheritdoc />
		public List<User> GetAll()
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public User Get(Guid id)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public User Create(User user)
		{
			throw new NotImplementedException();
		}
	}
}
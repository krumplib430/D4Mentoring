using System;
using System.Collections.Generic;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Repositories
{
	public class UserRepository : IUserRepository
	{
		/// <inheritdoc />
		public UserDto Create(UserCreateDto userCreateDto)
		{
			throw new NotImplementedException();
		}

		/// <inheritdoc />
		public List<UserListItemDto> GetAll()
		{
			return new List<UserListItemDto>
			{
				new UserListItemDto
				{
					Id = Guid.NewGuid(),
					FirstName = "aaaa",
					Lastname = "bbbbb",
					ConcurrencyToken = new byte[0]
				}
			};
		}
	}
}
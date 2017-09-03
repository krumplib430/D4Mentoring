using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Repositories
{
	public interface IUserRepository
	{
		Task<UserDto> GetAsync(Guid id);

		Task<UserDto> CreateAsync(UserCreateDto userCreateDto);

		List<UserListItemDto> GetAll();
	}
}
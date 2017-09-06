using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Repositories
{
	public interface IUserRepository
	{
		Task<UserDto> GetAsync(Guid id);

		Task<List<UserListItemDto>> GetAllAsync();

		Task<UserDto> CreateAsync(UserCreateDto userCreateDto);

		Task UpdateAsync(UserUpdateDto userUpdateDto);

		Task DeleteAsync(Guid id);
	}
}
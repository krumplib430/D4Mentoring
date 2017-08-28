using System.Collections.Generic;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Repositories
{
	public interface IUserRepository
	{
		UserDto Create(UserCreateDto userCreateDto);

		List<UserListItemDto> GetAll();
	}
}
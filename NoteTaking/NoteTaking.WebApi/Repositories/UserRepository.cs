using System;
using System.Collections.Generic;
using NoteTaking.Common.Mapping;
using NoteTaking.Models;
using NoteTaking.Service.Contracts;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IMappingService _mappingService;
		private readonly IUserService _userService;

		public UserRepository(IMappingService mappingService, IUserService userService)
		{
			_mappingService = mappingService;
			_userService = userService;
		}

		public UserDto Get(Guid id)
		{
			var user = _userService.Get(id);
			return _mappingService.Map<User, UserDto>(user);
		}

		/// <inheritdoc />
		public List<UserListItemDto> GetAll()
		{
			var users = _userService.GetAll();
			return _mappingService.Map<List<User>, List<UserListItemDto>>(users);
		}

		/// <inheritdoc />
		public UserDto Create(UserCreateDto userCreateDto)
		{
			var userDtoToCreate = _mappingService.Map<UserCreateDto, User>(userCreateDto);
			var createdUser = _userService.Create(userDtoToCreate);

			return _mappingService.Map<User, UserDto>(createdUser);
		}
	}
}
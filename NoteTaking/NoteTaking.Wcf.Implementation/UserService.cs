using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteTaking.Common.Mapping;
using NoteTaking.Models;
using NoteTaking.Wcf.Contracts.Interfaces;
using NoteTaking.Wcf.Contracts.Models;

namespace NoteTaking.Wcf.Implementation
{
	public class UserService : IUserService
	{
		private readonly Service.Contracts.IUserService _userService;
		private readonly IMappingService _mappingService;

		public UserService(Service.Contracts.IUserService userService, IMappingService mappingService)
		{
			_userService = userService;
			_mappingService = mappingService;
		}

		public async Task<UserDto> CreateAsync(UserCreateDto userCreateDto)
		{
			var user = _mappingService.Map<UserCreateDto, User>(userCreateDto);
			var createdUser = await _userService.CreateAsync(user);

			return _mappingService.Map<User, UserDto>(createdUser);
		}

		public async Task<UserDto> GetAsync(Guid id)
		{
			var user = await _userService.GetAsync(id);

			return _mappingService.Map<User, UserDto>(user);
		}

		public async Task<List<UserListItemDto>> GetAll()
		{
			var users = await _userService.GetAllAsync();

			return _mappingService.Map<List<User>, List<UserListItemDto>>(users);
		}
	}
}
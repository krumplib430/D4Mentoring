using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

		public async Task<UserDto> GetAsync(Guid id)
		{
			var user = await _userService.GetAsync(id);
			return _mappingService.Map<User, UserDto>(user);
		}

		/// <inheritdoc />
		public async Task<List<UserListItemDto>> GetAllAsync()
		{
			var users = await _userService.GetAllAsync();
			return _mappingService.Map<List<User>, List<UserListItemDto>>(users);
		}

		/// <inheritdoc />
		public async Task<UserDto> CreateAsync(UserCreateDto userCreateDto)
		{
			var user = _mappingService.Map<UserCreateDto, User>(userCreateDto);
			var createdUser = await _userService.CreateAsync(user);

			return _mappingService.Map<User, UserDto>(createdUser);
		}

		public async Task UpdateAsync(UserUpdateDto userUpdateDto)
		{
			var user = _mappingService.Map<UserUpdateDto, User>(userUpdateDto);
			await _userService.UpdateAsync(user);
		}

		public async Task DeleteAsync(Guid id)
		{
			await _userService.DeleteAsync(id);
		}
	}
}
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
	}
}
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using NoteTaking.Wcf.Contracts.Models;

namespace NoteTaking.Wcf.Contracts.Interfaces
{
	[ServiceContract]
	public interface IUserService
	{
		[OperationContract]
		Task<UserDto> CreateAsync(UserCreateDto userCreateDto);

		[OperationContract]
		Task<UserDto> GetAsync(Guid id);

		[OperationContract]
		Task<List<UserListItemDto>> GetAll();
	}
}
using AutoMapper;
using NoteTaking.Common.Mapping;
using NoteTaking.Models;
using NoteTaking.WebApi.Models;

namespace NoteTaking.WebApi.Bootstrap
{
	public class WebApiMappingConfiguration : IMappingConfiguration
	{
		/// <inheritdoc />
		public void Configure(IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<UserCreateDto, User>();
			cfg.CreateMap<User, UserDto>();
			cfg.CreateMap<User, UserListItemDto>();
		}
	}
}
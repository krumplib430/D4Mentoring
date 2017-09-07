using AutoMapper;
using NoteTaking.Common.Mapping;
using NoteTaking.Models;
using NoteTaking.Wcf.Contracts.Models;

namespace NoteTaking.Wcf.Implementation.Bootstrap
{
	public class WcfMappingConfiguration : IMappingConfiguration
	{
		public void Configure(IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<UserCreateDto, User>();
			cfg.CreateMap<User, UserDto>();

			cfg.CreateMap<NoteCreateDto, Note>();
			cfg.CreateMap<Note, NoteDto>();
		}
	}
}
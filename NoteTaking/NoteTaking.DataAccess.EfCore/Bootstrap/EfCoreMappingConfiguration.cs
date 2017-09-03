using AutoMapper;
using NoteTaking.Common.Mapping;
using NoteTaking.DataAccess.EfCore.Models;
using NoteTaking.Models;

namespace NoteTaking.DataAccess.EfCore.Bootstrap
{
	public class EfCoreMappingConfiguration : IMappingConfiguration
	{
		public void Configure(IMapperConfigurationExpression cfg)
		{
			cfg.CreateMap<User, UserDao>().ReverseMap();

			cfg.CreateMap<Note, NoteDao>().ReverseMap();
		}
	}
}
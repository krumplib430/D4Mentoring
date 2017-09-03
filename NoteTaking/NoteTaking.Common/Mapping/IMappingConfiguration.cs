using AutoMapper;

namespace NoteTaking.Common.Mapping
{
	public interface IMappingConfiguration
	{
		void Configure(IMapperConfigurationExpression cfg);
	}
}
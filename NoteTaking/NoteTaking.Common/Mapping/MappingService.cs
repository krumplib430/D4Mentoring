using AutoMapper;

namespace NoteTaking.Common.Mapping
{
	public class MappingService : IMappingService
	{
		public TDestination Map<TSource, TDestination>(TSource sourceObject)
		{
			return Mapper.Map<TSource, TDestination>(sourceObject);
		}
	}
}
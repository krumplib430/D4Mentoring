namespace NoteTaking.Common.Mapping
{
	public interface IMappingService
	{
		TDestination Map<TSource, TDestination>(TSource sourceObject);
	}
}
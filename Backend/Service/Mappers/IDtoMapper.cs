namespace Services.Mappers
{
    public interface IDtoMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object source);
    }
}

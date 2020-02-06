namespace DataAccess.Commons
{
    public interface IMapper<T, TY>
    {
        T Map(TY dto);

        TY Map(T entity);
    }
}

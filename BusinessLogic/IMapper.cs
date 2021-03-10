namespace BusinessLogic
{
    public interface IMapper
    {
        public TDestanation Map<TSource, TDestanation>(TSource source);
    }
}

using AutoMapper;

namespace BusinessLogic
{
    public class AutoMapperImplementation : IMapper
    {
        public TDestanation Map<TSource, TDestanation>(TSource source)
        {
            var config = new MapperConfiguration(config => config.CreateMap<TSource, TDestanation>());
            var mapper = config.CreateMapper();
            return mapper.Map<TDestanation>(source);
        }
    }
}

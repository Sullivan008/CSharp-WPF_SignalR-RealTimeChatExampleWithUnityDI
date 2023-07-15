using Microsoft.Extensions.DependencyInjection;
using SullyTech.Mapper.Core.Interfaces;
using SullyTech.Mapper.Services.Mapper.Interfaces;

namespace SullyTech.Mapper.Services.Mapper;

public sealed class MapperService : IMapperService
{
    private readonly IServiceProvider _serviceProvider;

    public MapperService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public TResult Map<TSource, TResult>(TSource source)
    {
        IMapper<TSource, TResult> mapper = _serviceProvider.GetRequiredService<IMapper<TSource, TResult>>();

        return mapper.Map(source);
    }
}
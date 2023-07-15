using SullyTech.Mapper.Core.Interfaces;

namespace SullyTech.Mapper.Core.Abstractions;

public abstract class Mapper<TSource, TResult> : IMapper<TSource, TResult>
{
    public abstract TResult Map(TSource source);
}
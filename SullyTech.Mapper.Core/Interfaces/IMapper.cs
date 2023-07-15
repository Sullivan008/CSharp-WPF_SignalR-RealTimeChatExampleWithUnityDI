namespace SullyTech.Mapper.Core.Interfaces;

public interface IMapper<in TSource, out TResult>
{
    public TResult Map(TSource source);
}
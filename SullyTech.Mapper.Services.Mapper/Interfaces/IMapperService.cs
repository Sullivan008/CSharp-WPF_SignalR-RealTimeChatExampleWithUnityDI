namespace SullyTech.Mapper.Services.Mapper.Interfaces;

public interface IMapperService
{
    public TResult Map<TSource, TResult>(TSource source);
}
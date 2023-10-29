using System.Linq.Expressions;
using AutoMapper;

namespace SullyTech.AutoMapper.Extensions;

public static class AutoMapperExtensions
{
    public static IMappingExpression<TSource, TDestination> MapIf<TSource, TDestination>(this IMappingExpression<TSource, TDestination> @this,
        Expression<Func<TDestination, object>> destinationMember, Func<TSource, bool> condition, Expression<Func<TSource, object>> mapExpression)
    {
        @this.ForMember(destinationMember, memberOptions =>
        {
            memberOptions.MapFrom(mapExpression);
            memberOptions.PreCondition(condition);
        });

        return @this;
    }
}
using MediatR;
using SullyTech.Web.Api.Cqrs.Core;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;
using SullyTech.Web.Api.Cqrs.Query.Interfaces;

namespace SullyTech.Web.Api.Cqrs.Query.Handlers.Abstractions;

public abstract class QueryHandler<TQuery> : IRequestHandler<TQuery, IResult>
    where TQuery : IQuery
{
    protected readonly IResult Result = new Result();

    public abstract Task<IResult> Handle(TQuery request, CancellationToken cancellationToken = default);
}
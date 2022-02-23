using Application.BusinessLogic.Core.MediatR.Queries.Abstractions;
using Application.BusinessLogic.Core.MediatR.Queries.Models.ResponseModels.Interfaces;
using MediatR;

namespace Application.BusinessLogic.Core.MediatR.QueryHandlers.Abstractions;

public abstract class MediatRQueryHandler<TMediatRQueryRequest, TMediatRQueryResponseModel> : IRequestHandler<TMediatRQueryRequest, TMediatRQueryResponseModel> 
    where TMediatRQueryRequest : MediatRQuery<TMediatRQueryResponseModel>
    where TMediatRQueryResponseModel : IMediatRQueryResponseModel
{
    public abstract Task<TMediatRQueryResponseModel> Handle(TMediatRQueryRequest query, CancellationToken cancellationToken);
}
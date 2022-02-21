using Application.BusinessLogic.Core.MediatR.Queries.Models.ResponseModels.Interfaces;
using MediatR;

namespace Application.BusinessLogic.Core.MediatR.Queries.Abstractions;

public abstract class MediatRQuery<TMediatRQueryResponseModel> : IRequest<TMediatRQueryResponseModel>
    where TMediatRQueryResponseModel : IMediatRQueryResponseModel
{ }
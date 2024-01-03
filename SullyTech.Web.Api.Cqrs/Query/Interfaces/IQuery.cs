using MediatR;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;

namespace SullyTech.Web.Api.Cqrs.Query.Interfaces;

public interface IQuery : IRequest<IResult>
{ }
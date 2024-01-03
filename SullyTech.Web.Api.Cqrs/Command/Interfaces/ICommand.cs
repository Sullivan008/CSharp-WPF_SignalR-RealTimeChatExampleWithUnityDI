using MediatR;
using SullyTech.Web.Api.Cqrs.Core.Interfaces;

namespace SullyTech.Web.Api.Cqrs.Command.Interfaces;

public interface ICommand : IRequest<IResult>
{ }
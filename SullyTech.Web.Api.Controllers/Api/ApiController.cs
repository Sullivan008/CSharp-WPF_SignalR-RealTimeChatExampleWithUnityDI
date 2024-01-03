using System.Net;
using Microsoft.AspNetCore.Mvc;
using SullyTech.Web.Api.ErrorHandling.Core.Models;
using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.Controllers.Api;

public class ApiController : ControllerBase
{
    public ObjectResult ProblemWithErrors(Error error)
    {
        Guard.Guard.ThrowIfNull(error);

        switch (error)
        {
            case ValidationError validationError:
                {
                    Guard.Guard.ThrowIfNullOrEmpty(validationError.Errors);

                    ProblemDetails problemDetails = ProblemDetailsFactory.CreateProblemDetails(httpContext: HttpContext,
                                                                                               statusCode: (int)HttpStatusCode.BadRequest,
                                                                                               title: validationError.Title);

                    problemDetails.Extensions.Add("errors", validationError.Errors);

                    return new ObjectResult(problemDetails)
                    {
                        StatusCode = problemDetails.Status
                    };
                }
            case ModelStateError modelStateError:
                {
                    Guard.Guard.ThrowIfNullOrEmpty(modelStateError.Errors);

                    ProblemDetails problemDetails = ProblemDetailsFactory.CreateProblemDetails(httpContext: HttpContext,
                                                                                               statusCode: (int)HttpStatusCode.InternalServerError,
                                                                                               title: modelStateError.Title);

                    problemDetails.Extensions.Add("errors", modelStateError.Errors);

                    return new ObjectResult(problemDetails)
                    {
                        StatusCode = problemDetails.Status
                    };
                }
            case ApplicationError applicationError:
                {
                    ProblemDetails problemDetails = ProblemDetailsFactory.CreateProblemDetails(httpContext: HttpContext,
                                                                                               statusCode: (int)HttpStatusCode.InternalServerError,
                                                                                               title: applicationError.Title,
                                                                                               detail: applicationError.Detail);

                    return new ObjectResult(problemDetails)
                    {
                        StatusCode = problemDetails.Status
                    };
                }
            default:
                throw new NotImplementedException(
                    $"Does not implemented - {nameof(ProblemWithErrors)} - Operation for following Window Type [Type: {error.GetType().FullName}]");
        }
    }
}
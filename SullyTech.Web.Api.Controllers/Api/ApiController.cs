using System.Net;
using Microsoft.AspNetCore.Mvc;
using SullyTech.Web.Api.ErrorHandling.Core.Models;

namespace SullyTech.Web.Api.Controllers.Api;

public class ApiController : ControllerBase
{
    public ObjectResult ProblemWithErrors(ValidationError error)
    {
        Guard.Guard.ThrowIfNull(error);
        Guard.Guard.ThrowIfNullOrEmpty(error.Errors);

        ProblemDetails problemDetails = ProblemDetailsFactory.CreateProblemDetails(httpContext: HttpContext,
                                                                                   statusCode: (int)HttpStatusCode.BadRequest,
                                                                                   title: error.Title);

        problemDetails.Extensions.Add("errors", error.Errors);

        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    public ObjectResult ProblemWithErrors(ModelStateError error)
    {
        Guard.Guard.ThrowIfNull(error);
        Guard.Guard.ThrowIfNullOrEmpty(error.Errors);

        ProblemDetails problemDetails = ProblemDetailsFactory.CreateProblemDetails(httpContext: HttpContext,
                                                                                   statusCode: (int)HttpStatusCode.InternalServerError,
                                                                                   title: error.Title);

        problemDetails.Extensions.Add("errors", error.Errors);

        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }

    public ObjectResult ProblemWithErrors(ApplicationError error)
    {
        Guard.Guard.ThrowIfNull(error);

        ProblemDetails problemDetails = ProblemDetailsFactory.CreateProblemDetails(httpContext: HttpContext,
                                                                                   statusCode: (int)HttpStatusCode.InternalServerError,
                                                                                   title: error.Title,
                                                                                   detail: error.Detail);

        return new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }
}
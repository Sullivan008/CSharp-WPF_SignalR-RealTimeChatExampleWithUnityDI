using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SullyTech.Web.Api.ErrorHandling.Core.Models;
using SullyTech.Web.Api.ErrorHandling.Core.Models.Abstractions;

namespace SullyTech.Web.Api.Controllers.Api;

[ApiController]
public class ApiController : ControllerBase
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ApiController(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    [NonAction]
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

                    if (_webHostEnvironment.IsDevelopment())
                    {
                        problemDetails.Extensions.Add("headers", HttpContext.Request.Headers);
                        problemDetails.Extensions.Add("path", HttpContext.Request.Path);
                        problemDetails.Extensions.Add("endpoint", HttpContext.GetEndpoint()?.DisplayName);
                        problemDetails.Extensions.Add("routeValues", HttpContext.Request.RouteValues);
                    }

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
                                                                                               statusCode: (int)HttpStatusCode.BadRequest,
                                                                                               title: modelStateError.Title);

                    if (_webHostEnvironment.IsDevelopment())
                    {
                        problemDetails.Extensions.Add("headers", HttpContext.Request.Headers);
                        problemDetails.Extensions.Add("path", HttpContext.Request.Path);
                        problemDetails.Extensions.Add("endpoint", HttpContext.GetEndpoint()?.DisplayName);
                        problemDetails.Extensions.Add("routeValues", HttpContext.Request.RouteValues);
                    }

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

                    if (_webHostEnvironment.IsDevelopment())
                    {
                        problemDetails.Extensions.Add("headers", HttpContext.Request.Headers);
                        problemDetails.Extensions.Add("path", HttpContext.Request.Path);
                        problemDetails.Extensions.Add("endpoint", HttpContext.GetEndpoint()?.DisplayName);
                        problemDetails.Extensions.Add("routeValues", HttpContext.Request.RouteValues);
                    }

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
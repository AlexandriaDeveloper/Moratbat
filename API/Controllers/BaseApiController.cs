using API.Helper.Response;
using Application.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BaseApiController : ControllerBase
{
    protected readonly IMediator _mediator;

    public BaseApiController(IMediator mediator)
    {
        this._mediator = mediator;
    }
    protected ActionResult HandleFailureResult(Result result)
   => result switch
   {
       { IsSuccess: true } => throw new InvalidOperationException(),
       { Error.Code: "Not Found" } => NotFound(CreateProblemDetails(
                   "Not Found Error", StatusCodes.Status404NotFound,
                   result.Error
                   )),
       { Error.Code: "Dublication" } => BadRequest(CreateProblemDetails(
                "Dublication", StatusCodes.Status400BadRequest,
                result.Error
                )),
       //    IValidationResult validationResult =>
       //        BadRequest(
       //            CreateProblemDetails(
       //                "Validation Error", StatusCodes.Status400BadRequest,
       //                result.Error,
       //                validationResult.Errors)),
       _ =>
           BadRequest(
               CreateProblemDetails(
                   "Bad Request",
                   StatusCodes.Status400BadRequest,
                   result.Error))
   };

    private static ProblemDetails CreateProblemDetails(
    string title,
    int status,
    Error error,
    Error[] errors = null) =>
    new()
    {
        Title = title,
        Type = error.Code,
        Detail = error.Message,
        Status = status,
        Extensions = { { nameof(errors), errors } }
    };
}


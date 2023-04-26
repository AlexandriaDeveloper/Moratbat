using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Helper.Response;
using Application.Common;
using Application.Features.Employees.Commands.UploadFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers;
[Authorize]
public class EmployeeController : BaseApiController
{
    // private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IMediator mediator) : base(mediator)
    {

        //   _logger = logger;
    }

    [HttpPost("fileUpload")]


    public async Task<IActionResult> FileUpload([FromForm] IFormFile file)
    {

        var result = await _mediator.Send(new UploadEmployeeCommand(file));
        if (result.IsFailure)
        {
            return HandleFailureResult(result);
        }
        return result.IsSuccess ? Ok(result) : NotFound(result.Error);

    }

    [HttpGet("getEmployees")]
    public async Task<IActionResult> GetEmployees()
    {
        List<string> result2 = new List<string>() { "mohamed", "ahmed", "sara" };
        //  var result = Result<string>.Failure(new Error("1", "test code"));
        var result = Result<string>.Success(result2);

        if (result.IsFailure)
        {
            return HandleFailureResult(result);

        }

        return result.IsSuccess ? Ok(result.Value) : NotFound(result.Error);

    }


}

public class EmployeeFileDto
{
    public IFormFile File { get; set; }
}
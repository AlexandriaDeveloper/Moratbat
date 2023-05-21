
using Application.Features.Employees.Commands.UploadFile;
using Application.Features.Employees.Queries.GetEmployeeBasicInfo;
using Application.Features.Employees.Queries.GetEmployeeBasicInfoByCode;
using Application.Features.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants;

namespace API.Controllers;
[Authorize]
public class EmployeeController : BaseApiController
{
    // private readonly ILogger<EmployeeController> _logger;

    public EmployeeController(IMediator mediator) : base(mediator)
    {

        //   _logger = logger;
    }

    [HttpPost("employeeFileUpload")]
    public async Task<IActionResult> FileUpload([FromForm] EmployeeFileUploadDto file)
    {

        var result = await _mediator.Send(new UploadEmployeeCommand(file));
        if (result.IsFailure)
        {
            return HandleFailureResult(result);
        }
        return result.IsSuccess ? Ok(result) : NotFound(result.Error);

    }

    [HttpGet("getEmployees")]
    public async Task<IActionResult> GetEmployees([FromQuery] EmployeeParam param)
    {
        var result = await _mediator.Send(new GetEmployeesQuery(param));
        if (result.IsFailure)
        {
            return HandleFailureResult(result);
        }
        return result.IsSuccess ? Ok(result) : NotFound(result.Error);

    }

    [HttpGet("getEmployeeBasicInfo/{id}")]
    public async Task<IActionResult> GetEmployeeBasicInfo(int id)
    {
        var result = await _mediator.Send(new GetEmployeeBasicInfoQuery(id));
        if (result.IsFailure)
        {
            return HandleFailureResult(result);
        }
        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }
    [HttpGet("getEmployeeBasicInfoByCode")]
    public async Task<IActionResult> GetEmployeeBasicInfoByCode([FromQuery] EmployeeByCodeRequest param)
    {
        var result = await _mediator.Send(new GetEmployeeBasicInfoByCodeQuery(param));
        if (result.IsFailure)
        {
            return HandleFailureResult(result);
        }
        return result.IsSuccess ? Ok(result) : NotFound(result.Error);
    }
}

public class EmployeeFileDto
{
    public IFormFile File { get; set; }
}
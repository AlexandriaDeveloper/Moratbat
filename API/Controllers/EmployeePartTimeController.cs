using Application.Features.EmployeePartTime.Commands.AddPartTimeToEmployee;
using Application.Features.EmployeePartTime.Commands.EndPartTimeForEmployee;
using Application.Features.EmployeePartTime.Queries.GetEmployeePartTimeHistoryByEmployeeId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class EmployeePartTimeController : BaseApiController
    {


        public EmployeePartTimeController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("getEmployeePartTimeHistoryByEmployeeId")]
        public async Task<IActionResult> GetEmployeePartTimeHistoryByEmployeeId([FromQuery] int employeeId)
        {
            var result = await _mediator.Send(new GetEmployeePartTimeHistoryByEmployeeIdQuery(employeeId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [AllowAnonymous]
        [HttpPost("addPartTimeToEmployee")]
        public async Task<IActionResult> AddPartTimeToEmployee([FromBody] EmployeePartTimeDto model)
        {
            var result = await _mediator.Send(new AddPartTimeToEmployeeCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [AllowAnonymous]
        [HttpPost("endPartTimeToEmployee")]
        public async Task<IActionResult> EndPartTimeToEmployee([FromBody] EmployeePartTimeDto model)
        {
            var result = await _mediator.Send(new EndPartTimeForEmployeeCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
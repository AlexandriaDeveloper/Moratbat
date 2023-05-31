
using Application.Features.EmployeeGrade;
using Application.Features.EmployeeGrade.Commands;
using Application.Features.EmployeeGrade.Queries.GetEmployeeGradeByEmployeeId;
using Application.Features.EmployeeGrade.Queries.GetEmployeeGradeByParentId;
using Application.Features.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants;

namespace API.Controllers
{
    public class EmployeeGradeController : BaseApiController
    {
        public EmployeeGradeController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("employeeGradeByEmployeeId")]
        public async Task<IActionResult> GetEmployeeGrade([FromQuery] EmployeeGradeParam model)
        {
            var result = await _mediator.Send(new GetEmployeeGradeByEmployeeIdQuery(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

        [HttpPut("updateEmployeeGrade")]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeGradeDto model)
        {
            var result = await _mediator.Send(new UpdateEmployeeGradeCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

        [HttpPost("newEmployeeGrade")]
        public async Task<IActionResult> NewEmployeeGrade([FromBody] EmployeeGradeDto model)
        {
            var result = await _mediator.Send(new AddEmployeeGradeCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
    }
}
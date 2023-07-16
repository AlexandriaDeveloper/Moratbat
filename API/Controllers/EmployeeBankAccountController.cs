
using Application.Features.EmployeeBank;
using Application.Features.EmployeeBank.Commands.AddEmployeeBankAccount;
using Application.Features.EmployeeBank.Commands.CloseEmployeeBankAccount;
using Application.Features.EmployeeBank.Commands.DeleteEmployeeAccount;
using Application.Features.EmployeeBank.Queries.GetEmployeeBnakByEmployeeId;
using MediatR;

using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{

    public class EmployeeBankController : BaseApiController
    {
        private readonly ILogger<EmployeeBankController> _logger;

        public EmployeeBankController(ILogger<EmployeeBankController> logger, IMediator mediator) : base(mediator)
        {
            _logger = logger;
        }


        [HttpGet("getEmployeeBankAccountByEmployeeId/{id}")]
        public async Task<IActionResult> GetEmployeeBank(int id)
        {
            var result = await _mediator.Send(new GetEmployeeBankByEmployeeIdQuery(id));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);



        }
        [HttpPost("editEmployeeBankAccount")]
        public async Task<IActionResult> AddEmployeeBankAccount([FromBody] EmployeeBankAccountRequest model)
        {
            var result = await _mediator.Send(new EditEmployeeBankAccountCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
        [HttpPut("closeEmployeeBankAccount")]
        public async Task<IActionResult> CloseEmployeeBankAccount([FromBody] CloseEmployeeBankAccountRequest model)
        {
            var result = await _mediator.Send(new CloseEmployeeBankAccountCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
        [HttpDelete("deleteEmployeeBankAccount")]
        public async Task<IActionResult> DeleteEmployeeBankAccount([FromQuery] int employeeId, int bankId)
        {
            var result = await _mediator.Send(new DeleteEmployeeAccountCommand(employeeId, bankId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
    }
}
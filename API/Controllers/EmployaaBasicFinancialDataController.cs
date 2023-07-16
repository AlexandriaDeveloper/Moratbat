
using Application.Features.EmployeeBasicFinancialData.Commands.AddEmployeeBasicFinancialData;
using Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeAccountTree;
using Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeAccountTreeAmountByAccountTreeId;
using Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeMokamelData;
using Application.Features.EmployeeBasicFinancialData.Queries.GetEmployeeWazifi;
using Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData;
using Application.Features.Employees.Queries.GetEmployees;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData.EmployeeBasicSallaryInfoDto;

namespace API.Controllers
{
    public class EmployaaBasicFinancialDataController : BaseApiController
    {
        public EmployaaBasicFinancialDataController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("getEmployeeData")]
        public async Task<IActionResult> GetEmployeeWazifiData(int employeeId, int accoutTreeId, DateTime peekDate)
        {
            var result = await _mediator.Send(new GetEmployeeDataByAccountTreeIdQuery(employeeId, accoutTreeId, peekDate));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpGet("getEmployeeMokamelData")]
        public async Task<IActionResult> GetEmployeeMokamelData(int employeeId, DateTime peekDate)
        {
            var result = await _mediator.Send(new getEmployeeMokamelDataQuery(employeeId, peekDate));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [AllowAnonymous]
        [HttpGet("getEmployeeAccountTree")]
        public async Task<IActionResult> GetEmployeeAccountTree(int employeeId, DateTime peekDate)
        {
            var result = await _mediator.Send(new GetEmployeeAccountTreeQuery(employeeId, peekDate));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        //GetEmployeeAccountTreeAmountByAccountTreeIdQuery
        [AllowAnonymous]
        [HttpGet("GetEmpAmountByAccountTreeId")]
        public async Task<IActionResult> GetEmployeeAccountTree(int employeeId, int accountTreeId, DateTime peekDate)
        {
            var result = await _mediator.Send(new GetEmployeeAccountTreeAmountByAccountTreeIdQuery(employeeId, accountTreeId, peekDate));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [AllowAnonymous]
        [HttpGet("getEmployeeDataByAccountTreeId")]
        public async Task<IActionResult> GetEmployeeBasicSallaryInfo(int employeeId, int accountTreeId, DateTime peekDate)
        {
            var result = await _mediator.Send(new GetEmployeeDataByAccountTreeIdQuery(employeeId, accountTreeId, peekDate));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpGet("getEmployeeBasicSallaryInfo")]
        public async Task<IActionResult> GetEmployeeBasicSallaryInfo(int employeeId, DateTime peekDate)
        {
            var result = await _mediator.Send(new GetEmployeeBasicSallaryInfoQuery(employeeId, peekDate));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost("addToEmployeeBasicFinancialData")]
        public async Task<IActionResult> AddToEmployeeBasicFinancialData([FromBody] EmployeeBasicFinancialDataDto model)
        {
            var result = await _mediator.Send(new AddEmployeeBasicFinancialDataCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost("uploadEmployeeBasicFinicialData")]
        public async Task<IActionResult> UploadEmployeeBasicFinicialData([FromForm] EmployeeFileUploadDto fileData)
        {
            var result = await _mediator.Send(new UploadEmployeeBasicFinancialDataCommand(fileData));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }


    }

    public class FormFileData
    {
        public IFormFile File { get; set; }
    }
}

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants.Param;
using Application.Features.EmployeeCollection.Queries.GetEmployeesInCollection;
using Application.Features.EmployeeCollection.Commands.AddEmployeeToCollection;
using Application.Constants;
using Application.Features.EmployeeCollection.Commands.UploadEmployeesToCollection;
using Application.Features.EmployeeCollection.Commands.DeleteEmployeeFromCollection;

namespace API.Controllers
{
    public class EmployeeCollectionController : BaseApiController
    {
        public EmployeeCollectionController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("getEmployeesInCollection/{id}")]
        public async Task<IActionResult> GetEmployeesInCollection(int id, [FromQuery] EmployeeInCollectionParam param)
        {
            var result = await _mediator.Send(new GetEmployeesInCollectionQuery(id, param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost("addEmployeeToCollection")]
        public async Task<IActionResult> AddEmployeeToCollection([FromBody] AddEmployeeToCollectionRequest param)
        {
            var result = await _mediator.Send(new AddEmployeeToCollectionCommand(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

        [HttpDelete("deleteEmployeeFromCollection/{id}")]
        public async Task<IActionResult> DeleteEmployeeFromCollection(int id)
        {
            var result = await _mediator.Send(new DeleteEmployeeFromCollectionCommand(id));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

        [HttpGet("download-employee-collection")]
        public async Task<ActionResult> GetPhoneNumberExcelFile()
        {
            string fileName = "Employee-Collection-template.xlsx";
            //string filePath = Path.Combine(_hostEnvironment.ContentRootPath, "Content\\" + fileName);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Content\\" + fileName);
            if (!System.IO.File.Exists(filePath))
                return NotFound();


            var memory = new MemoryStream();
            await using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }



        [HttpPost("uploadEmployeesToCollection")]
        public async Task<IActionResult> UploadEmployeesToCollection([FromForm] FileToUploadDto file)
        {

            var result = await _mediator.Send(new UploadEmployeesToCollectionCommand(file));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

    }
}
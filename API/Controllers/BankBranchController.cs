
using Application.Features.BankBranche;
using Application.Features.BankBranche.Commands.AddBankBranch;
using Application.Features.BankBranche.Commands.DeleteBranch;
using Application.Features.BankBranche.Queries.GetBankBranches;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants.Param;

namespace API.Controllers
{

    public class BankBranchController : BaseApiController
    {
        public BankBranchController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("getBranches")]
        public async Task<IActionResult> GetBranches([FromQuery] BankBranchParam param)
        {
            var result = await _mediator.Send(new GetBankBranchesQuery(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
        [HttpGet("getBranchesList")]
        public async Task<IActionResult> GetBranchesList([FromQuery] int BankId)
        {
            var result = await _mediator.Send(new GetBankBranchesListQuery(BankId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

        [HttpPost("addBranche")]
        public async Task<IActionResult> AddBranch([FromBody] BankBranchDto model)
        {
            var result = await _mediator.Send(new AddBankBranchCommand(model));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }

        [HttpDelete("deleteBranch/{branchId}")]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            var result = await _mediator.Send(new DeleteBranchCommand(branchId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
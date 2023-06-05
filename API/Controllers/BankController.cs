using Application.Features.Bank.Commands.AddBank;
using Application.Features.Bank.Commands.DeleteBank;
using Application.Features.Bank.Queries.GetBanks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants.Param;

namespace API.Controllers
{

    [AllowAnonymous]
    public class BankController : BaseApiController
    {
        public BankController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("getBanks")]
        public async Task<IActionResult> GetBanks([FromQuery] BankParam param)
        {
            var result = await _mediator.Send(new GetBanksQuery(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
        [HttpGet("getBankById")]
        public async Task<IActionResult> GetBankBy([FromQuery] BankParam param)
        {
            var result = await _mediator.Send(new GetBankByQuery(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost("addBank")]
        public async Task<IActionResult> GetBankBy([FromBody] BankDto bank)
        {
            var result = await _mediator.Send(new AddBankCommand(bank));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpDelete("deleteBank/{bankId}")]
        public async Task<IActionResult> DeleteBank(int bankId)
        {
            var result = await _mediator.Send(new DeleteBankCommand(bankId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
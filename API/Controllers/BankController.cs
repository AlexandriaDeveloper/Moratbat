
using Application.Features.Bank.Commands.AddBank;
using Application.Features.Bank.Commands.DeleteBank;
using Application.Features.Bank.Queries.GetBanks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants.Param;

namespace API.Controllers
{

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

        [HttpGet("getBankList")]
        public async Task<IActionResult> GetBankList()
        {
            var result = await _mediator.Send(new GetBankListQuery());
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);

        }
        [HttpGet("getBankById/{bankId}")]
        public async Task<IActionResult> GetBankBy(int bankId)
        {
            var result = await _mediator.Send(new GetBankByQuery(bankId));
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
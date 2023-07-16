
using Application.Features.AccountTree.Commands.AddAccountTree;
using Application.Features.AccountTree.Commands.AddAccountTreeDetails;
using Application.Features.AccountTree.Queries.GetChildrensAccountTree;
using Application.Features.AccountTree.Queries.GetMaxAccountTreeDetailsId;
using Application.Features.AccountTree.Queries.GetParentAccountTree;
using Application.Features.BudgetItems;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class AccountsTreeController : BaseApiController
    {
        public AccountsTreeController(IMediator mediator) : base(mediator)
        {
        }
        [HttpGet("getParentsAccountsTree")]
        public async Task<IActionResult> GetParentsAccountsTree()
        {
            var result = await _mediator.Send(new GetParentAccountsTreeQuery());
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [HttpGet("getChildrensAccountsTree")]
        public async Task<IActionResult> GetChildrensAccountsTree(int parentId)
        {
            var result = await _mediator.Send(new GetChildrenAccountsTreeQuery(parentId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }


        [HttpGet("getChildrensAccountsTreeData")]
        public async Task<IActionResult> GetChildrensAccountsTreeData(int childid)
        {
            var result = await _mediator.Send(new GetChildrenAccountsTreeDataQuery(childid));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }


        [HttpGet("getMaxId/{AccountTreeId}")]
        public async Task<IActionResult> GetMaxId(int AccountTreeId)
        {
            var result = await _mediator.Send(new GetMaxAccountTreeDetailsIdQuery(AccountTreeId));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost("addAccountTreeElement")]
        public async Task<IActionResult> AddAccountTreeElement([FromBody] AccountTreeDto request)
        {
            var result = await _mediator.Send(new AddAccountTreeCommand(request));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [HttpPost("addAccountTreeDataElement")]
        public async Task<IActionResult> AddAccountTreeDataElement([FromBody] AccountTreeDetailsDto request)
        {
            var result = await _mediator.Send(new AddAccountTreeDetailsCommand(request));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

    }
}
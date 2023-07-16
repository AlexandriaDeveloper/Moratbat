using Application.Features.Collection.Commands.AddCollection;
using Application.Features.Collection.Commands.CopyCollection;
using Application.Features.Collection.Commands.DeleteCollection;
using Application.Features.Collection.Queries.GetCollictions;
using Application.Features.Collection.Queries.GetEmployeesInCollection;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Constants.Param;

namespace API.Controllers
{

    public class CollectionController : BaseApiController
    {
        public CollectionController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("getCollections")]
        public async Task<IActionResult> GetCollections([FromQuery] CollectionParam param)
        {
            var result = await _mediator.Send(new GetCollictionsQuery(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpPost("addCollection")]
        public async Task<IActionResult> AddCollection([FromBody] CollectionDto param)
        {
            var result = await _mediator.Send(new AddCollectionCommand(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }


        [HttpPut("editCollection")]
        public async Task<IActionResult> EditCollection([FromBody] CollectionDto param)
        {
            var result = await _mediator.Send(new EditCollectionCommand(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [AllowAnonymous]
        [HttpPost("copyCollection")]
        public async Task<IActionResult> CopyCollection([FromBody] CopyCollectionRequest param)
        {
            var result = await _mediator.Send(new CopyCollectionCommand(param));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
        [HttpDelete("deleteCollection/{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            var result = await _mediator.Send(new DeleteCollectionCommand(id));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
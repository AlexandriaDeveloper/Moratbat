using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.EmployeeGrade.Queries.GetEmployeeGradeByParentId;
using Application.Features.Grade.Queries.GetGradeById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class GradeController : BaseApiController
    {
        public GradeController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("GetGradesByParentId/{id}")]
        public async Task<IActionResult> GetGradesByParentId(int? id)
        {
            var result = await _mediator.Send(new GetGradesByParentIdQuery(id));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }

        [HttpGet("GetGradeById/{id}")]
        public async Task<IActionResult> GetGrade(int id)
        {
            var result = await _mediator.Send(new GetGradeByIdQuery(id));
            if (result.IsFailure)
            {
                return HandleFailureResult(result);
            }
            return result.IsSuccess ? Ok(result) : NotFound(result.Error);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.EmployeeBank.Queries.GetEmployeeBnakByEmployeeId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    
    public class EmployeeBankController : BaseApiController
    {
        private readonly ILogger<EmployeeBankController> _logger;

        public EmployeeBankController(ILogger<EmployeeBankController> logger,IMediator mediator):base(mediator)
        {
            _logger = logger;
        }

   
    [HttpGet("getEmployeeBankAccountByEmployeeId/{id}")]
    public async Task<IActionResult> GetEmployeeBank( int id){
        var result = await _mediator.Send(new GetEmployeeBankByEmployeeIdQuery(id));
        if (result.IsFailure)
        {
            return HandleFailureResult(result);
        }
        return result.IsSuccess ? Ok(result) : NotFound(result.Error);

 

    }
      
    }
}
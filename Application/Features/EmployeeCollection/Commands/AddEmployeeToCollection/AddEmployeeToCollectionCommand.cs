using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using NPOI.OpenXmlFormats.Wordprocessing;

namespace Application.Features.EmployeeCollection.Commands.AddEmployeeToCollection
{
    public record AddEmployeeToCollectionCommand(AddEmployeeToCollectionRequest model) : ICommand;
    public class AddEmployeeToCollectionCommandHandler : ICommandHandler<AddEmployeeToCollectionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uOW;
        public AddEmployeeToCollectionCommandHandler(IUOW uOW, IMapper mapper)
        {
            this._uOW = uOW;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(AddEmployeeToCollectionCommand request, CancellationToken cancellationToken)
        {
            var employeeToColletionToDb = _mapper.Map<EmployeeCollectionModel>(request.model);
            await _uOW.EmployeeCollectionRepo.Insert(employeeToColletionToDb, cancellationToken);
            var result = await _uOW.SaveChangesAsync(cancellationToken);
            return result.IsSuccess ? Result.Success() : Result.Failure(new Error(result.ErrorCode, result.Message));
        }
    }
}
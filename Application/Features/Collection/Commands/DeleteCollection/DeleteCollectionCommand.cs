using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;

namespace Application.Features.Collection.Commands.DeleteCollection
{
    public record DeleteCollectionCommand(int Id) : ICommand;
    public class DeleteCollectionCommandHandler : ICommandHandler<DeleteCollectionCommand>
    {
        private readonly IUOW _uOW;
        private readonly IMapper _mapper;
        public DeleteCollectionCommandHandler(IUOW uOW, IMapper mapper)
        {
            this._mapper = mapper;
            this._uOW = uOW;

        }
        public async Task<Result> Handle(DeleteCollectionCommand request, CancellationToken cancellationToken)
        {
            var result = await _uOW.CollectionRepo.GetByIdAsync(request.Id);
            if (result == null)
            {
                return Result.Failure(new Error("404", "عفوا لم يتم العثور عليها"));
            }

            _uOW.CollectionRepo.Delete(result);
            var result1 = await _uOW.SaveChangesAsync(cancellationToken);
            if (result1.IsFailure)
            {
                return Result.Failure(new Error(result1.ErrorCode, result1.Message));
            }
            return Result.Success();
        }
    }
}
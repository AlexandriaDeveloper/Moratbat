using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Collection.Queries.GetCollictions;
using AutoMapper;

namespace Application.Features.Collection.Commands.AddCollection
{
    public record EditCollectionCommand(CollectionDto model) : ICommand;
    public class EditCollectionCommandHandler : ICommandHandler<EditCollectionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uOW;
        public EditCollectionCommandHandler(IUOW uOW, IMapper mapper)
        {
            this._uOW = uOW;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(EditCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = await _uOW.CollectionRepo.GetByIdAsync(request.model.Id);
            if (collection == null)
            {
                return Result.Failure(new Error("404", "عفوا لم يتم العثور عليها"));
            }
            collection.Name = request.model.Name;
            _uOW.CollectionRepo.Update(collection);
            var result = await _uOW.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();

        }
    }
}
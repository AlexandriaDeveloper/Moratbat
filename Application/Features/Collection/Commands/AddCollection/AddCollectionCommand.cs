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
    public record AddCollectionCommand(CollectionDto model) : ICommand;
    public class AddCollectionCommandHandler : ICommandHandler<AddCollectionCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uOW;
        public AddCollectionCommandHandler(IUOW uOW, IMapper mapper)
        {
            this._uOW = uOW;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(AddCollectionCommand request, CancellationToken cancellationToken)
        {
            var collection = _mapper.Map<CollectionModel>(request.model);
            await _uOW.CollectionRepo.Insert(collection, cancellationToken);
            var result = await _uOW.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();

        }
    }
}

using System.Security.Claims;
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Collection.Queries.GetCollictions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Collection.Commands.CopyCollection
{
    public record CopyCollectionCommand(CopyCollectionRequest model) : ICommand;
    public class CopyCollectionCommandHandler : ICommandHandler<CopyCollectionCommand>
    {
        private readonly IUOW _uOW;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CopyCollectionCommandHandler(IUOW uOW, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._mapper = mapper;
            this._uOW = uOW;

        }
        public async Task<Result> Handle(CopyCollectionCommand request, CancellationToken cancellationToken)
        {

            var employeeCollection = _uOW.CollectionRepo
            .GetQueryable()
           .Where(x => x.Id == request.model.CollectionId)
            .FirstOrDefault();
            if (employeeCollection == null)
            {
                return Result.Failure(new Error("404", "عفوا لم يتم العثور عليها"));
            }
            var collectionToCopy = _uOW.EmployeeCollectionRepo.GetQueryable().Where(x => x.CollectionId == request.model.CollectionId).ToList();

            var copiedCollection = new CollectionModel
            {
                Name = request.model.Name,
                EmployeeCollection = new List<EmployeeCollectionModel>()
            };
            collectionToCopy.ForEach(x =>
            {
                copiedCollection.EmployeeCollection.Add(new EmployeeCollectionModel()
                {
                    CollectionId = x.CollectionId,
                    EmployeeId = x.EmployeeId,
                    CreatedBy = _httpContextAccessor.HttpContext.User.FindFirstValue("UUID"),
                    CteaedAt = DateTime.Now.ToLocalTime()
                });
            });

            await _uOW.CollectionRepo.Insert(copiedCollection, cancellationToken);
            var result = await _uOW.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }

}
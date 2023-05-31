
using System.Security.Claims;
using System.Linq;
using Application.Common.Messaging;
using Application.Common;
using AutoMapper;
using Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Http;

namespace Application.Features.EmployeeGrade.Commands
{
    public record AddEmployeeGradeCommand(EmployeeGradeDto model) : ICommand;
    public class AddEmployeeGradeCommandHandler : ICommandHandler<AddEmployeeGradeCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor authService;

        public AddEmployeeGradeCommandHandler(IUOW uow, IMapper mapper, IHttpContextAccessor authService)
        {
            this._uow = uow;
            this._mapper = mapper;
            this.authService = authService;
        }
        public async Task<Result> Handle(AddEmployeeGradeCommand request, CancellationToken cancellationToken)
        {
            Domain.EmployeeGradeModel modelToDb = _mapper.Map<Domain.EmployeeGradeModel>(request.model);


            var lastGrade = _uow.EmployeeGradeRepo.GetQueryable().Where(x => x.EndAt.HasValue == false).ToList();
            lastGrade.ForEach(x =>
            {
                x.EndAt = request.model.StartFrom.AddDays(-1);
                x.UpdatedAt = DateTime.Now.ToLocalTime();
                x.UpdatedBy = authService.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "UUID").Value;
            });
            await _uow.EmployeeGradeRepo.Insert(modelToDb, cancellationToken);
            var SaveChangesAsyncResult = await _uow.SaveChangesAsync(cancellationToken);
            if (SaveChangesAsyncResult.IsFailure)
            {
                return Result.Failure(new Error("000", SaveChangesAsyncResult.Message));
            }

            return Result.Success();
        }
    }
}
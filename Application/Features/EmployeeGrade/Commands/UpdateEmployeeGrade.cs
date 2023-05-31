
using Application.Features.Employees.Queries.GetEmployees;
using Application.Common.Messaging;
using Application.Common;
using Domain.Interfaces.Repository;
using AutoMapper;
using Domain;

namespace Application.Features.EmployeeGrade.Commands
{
    public record UpdateEmployeeGradeCommand(EmployeeGradeDto employeeGrade) : ICommand;
    public class UpdateEmployeeGradeCommandHandler : ICommandHandler<UpdateEmployeeGradeCommand>
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public UpdateEmployeeGradeCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;
        }
        public async Task<Result> Handle(UpdateEmployeeGradeCommand request, CancellationToken cancellationToken)
        {
            var empFromDb = _mapper.Map<EmployeeGradeDto, EmployeeGradeModel>(request.employeeGrade);
            _uow.EmployeeGradeRepo.Update(empFromDb);
            await _uow.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

}
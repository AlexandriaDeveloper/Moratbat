
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.EmployeePartTime.Commands.AddPartTimeToEmployee;


public record AddPartTimeToEmployeeCommand(EmployeePartTimeDto model) : ICommand;

public class AddPartTimeToEmployeeCommandHandler : ICommandHandler<AddPartTimeToEmployeeCommand>
{
    private readonly IUOW _uOW;
    private readonly IMapper _mapper;
    public AddPartTimeToEmployeeCommandHandler(IUOW uOW, IMapper mapper)
    {
        this._mapper = mapper;
        this._uOW = uOW;
    }

    public async Task<Result> Handle(AddPartTimeToEmployeeCommand request, CancellationToken cancellationToken)
    {

        var employeePartTimeList = await _uOW.EmployeePartTimeRepo.GetQueryable().Where(x => x.EmployeeId == request.model.EmployeeId).ToListAsync(cancellationToken);
        if (employeePartTimeList.Count > 0)
        {
            if (employeePartTimeList.Any(x => x.InPartTime))
            {
                return Result.Failure(new Error("", "لايمكن تسجيل الموظف جزء من الوقت حيث انة بالفعل جزء من الوقت"));
            }
        }


        var entityToDb = _mapper.Map<EmployeePartTimeModel>(request.model);
        await _uOW.EmployeePartTimeRepo.Insert(entityToDb, cancellationToken);
        var result = await _uOW.SaveChangesAsync(cancellationToken);
        if (result.IsFailure)
        {
            return Result.Failure(new Error(result.ErrorCode, result.Message));
        }

        return Result.Success();
    }
}


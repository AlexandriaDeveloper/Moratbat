
using Application.Common;
using Application.Common.Messaging;
using Application.Features.EmployeePartTime.Commands.AddPartTimeToEmployee;
using AutoMapper;
using MediatR;

namespace Application.Features.EmployeePartTime.Commands.EndPartTimeForEmployee;


public record EndPartTimeForEmployeeCommand(EmployeePartTimeDto model) : ICommand;

public class EndPartTimeForEmployeeCommandHandler : ICommandHandler<EndPartTimeForEmployeeCommand>
{
    private readonly IUOW _uOW;
    private readonly IMapper _mapper;
    public EndPartTimeForEmployeeCommandHandler(IUOW uOW, IMapper mapper)
    {
        this._mapper = mapper;
        this._uOW = uOW;
    }

    public async Task<Result> Handle(EndPartTimeForEmployeeCommand request, CancellationToken cancellationToken)
    {
        var entityToDb = _uOW.EmployeePartTimeRepo.GetQueryable().Where(x => x.Id == request.model.Id);
        if (!entityToDb.Any())
        {
            return Result.Failure(new Error("", "عفوا الموظف ليس لديه جزء من الوقت حاليا لاغلاقة الوقت"));
        }
        entityToDb.FirstOrDefault().EndDate = request.model.EndDate;
        var result = await _uOW.SaveChangesAsync(cancellationToken);
        if (result.IsFailure)
        {
            return Result.Failure(new Error(result.ErrorCode, result.Message));
        }

        return Result.Success();
    }
}


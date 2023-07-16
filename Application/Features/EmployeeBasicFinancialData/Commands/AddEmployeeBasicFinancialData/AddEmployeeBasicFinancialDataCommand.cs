
using Application.Common;
using Application.Common.Messaging;
using AutoMapper;
using static Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData.EmployeeBasicSallaryInfoDto;

namespace Application.Features.EmployeeBasicFinancialData.Commands.AddEmployeeBasicFinancialData
{
    public record AddEmployeeBasicFinancialDataCommand(EmployeeBasicFinancialDataDto model) : ICommand;
    public class AddEmployeeBasicFinancialDataCommandHandler : ICommandHandler<AddEmployeeBasicFinancialDataCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUOW _uow;
        public AddEmployeeBasicFinancialDataCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(AddEmployeeBasicFinancialDataCommand request, CancellationToken cancellationToken)
        {
            await _uow.EmployeeBasicFinancialDataRepo.Insert(new EmployeeBasicFinancialDataModel()
            {

                EmployeeId = request.model.EmployeeId,
                AccountTreeDetailsId = request.model.AccountTreeDetailsId,
                AccountTreeDetailsAccountTreeId = request.model.AccountTreeDetailsAccountTreeId,
                Amount = request.model.Amount,
                Repeat = request.model.Repeat,
                StartDate = request.model.StartDate,
                FinancialSource = request.model.FinancialSource,
            }, cancellationToken);
            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                return Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }
    }
}
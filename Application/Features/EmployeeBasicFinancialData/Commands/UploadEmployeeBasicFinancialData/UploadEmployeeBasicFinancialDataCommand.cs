
using Application.Common;
using Application.Common.Messaging;
using Application.Features.Employees.Queries.GetEmployees;
using Application.Services;
using AutoMapper;
using Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Application.Features.EmployeeBasicFinancialData.UploadEmployeeBasicFinancialData
{
    public record UploadEmployeeBasicFinancialDataCommand(EmployeeFileUploadDto file) : ICommand;
    public partial class UploadEmployeeBasicFinancialDataCommandHandler : ICommandHandler<UploadEmployeeBasicFinancialDataCommand>
    {
        private readonly IMapper _mapper;

        private readonly IUOW _uow;
        public UploadEmployeeBasicFinancialDataCommandHandler(IUOW uow, IMapper mapper)
        {
            this._uow = uow;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(UploadEmployeeBasicFinancialDataCommand request, CancellationToken cancellationToken)
        {
            if (request.file.File == null)
                return Result.Failure(new Error("404", " الملف غير موجود "));
            var tempPath = await CopyFile(request.file.File);

            NPOIServiceReadEmployeeFinancialData npoi = new NPOIServiceReadEmployeeFinancialData();
            TablStructure dt = npoi.ReadEmployeeBasicFinancialDataFile(tempPath, "Sheet1");

            foreach (var col in dt.Columns)
            {
                var financialSourc = col.FinancialSource == "ذاتى" ? 0 : 1;
                var startDate = col.StartDate;
                var AccountTreeId = col.AccountTreeId;
                var AccountTreeDetailsId = col.AccountTreeDetailsId;

                foreach (var row in col.Rows)
                {
                    var emp = _uow.EmployeeRepo.GetQueryable().FirstOrDefault(x => x.TegaraCode == row.EmployeeTegaraCode);
                    if (emp == null)
                    {
                        return Result.Failure(new Error("404", $@"عفوا  تأكد من صحة الكود رقم ${row.EmployeeTegaraCode}"));
                    }
                    await _uow.EmployeeBasicFinancialDataRepo.Insert(new EmployeeBasicFinancialDataModel()
                    {
                        Amount = row.Amount,
                        EmployeeId = emp.Id,
                        AccountTreeDetailsId = AccountTreeDetailsId,
                        AccountTreeDetailsAccountTreeId = AccountTreeId,
                        Repeat = true,
                        StartDate = startDate.Value.ToLocalTime(),
                        FinancialSource = (FinancialSourceEnum)financialSourc,
                    }, cancellationToken);

                }


            }


            var result = await _uow.SaveChangesAsync(cancellationToken);
            if (result.IsFailure)
            {
                Result.Failure(new Error(result.ErrorCode, result.Message));
            }
            return Result.Success();
        }

        private async Task<string> CopyFile(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var tempPath = Path.GetTempPath();//+ Path.GetTempFileName();
            var fileName = Path.ChangeExtension(Guid.NewGuid().ToString(), ext);
            tempPath = Path.Combine(tempPath, fileName);
            if (System.IO.File.Exists(tempPath))
            {
                System.IO.File.Delete(tempPath);
            }
            using (var fileStream = new FileStream(tempPath, FileMode.Create))
            {

                await file.CopyToAsync(fileStream);
            }
            return tempPath;
        }


    }
}
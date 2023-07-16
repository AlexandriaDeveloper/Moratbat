using Application.Common.Messaging;
using Application.Common;
using Application.Services;
using Microsoft.AspNetCore.Http;
using System.Data;
using Domain.Constants;
using Application.Features.Employees.Queries.GetEmployees;
using System.Security.Claims;

namespace Application.Features.Employees.Commands.UploadFile
{
    public record UploadEmployeeCommand(EmployeeFileUploadDto file) : ICommand;
    public class UploadEmployeeCommandHandler : ICommandHandler<UploadEmployeeCommand>
    {
        private readonly INPOIService _npoi;
        private readonly IUOW _context;

        private readonly IHttpContextAccessor _accessor;

        public UploadEmployeeCommandHandler(INPOIService npoi, IUOW context, IHttpContextAccessor accessor)
        {
            this._accessor = accessor;

            this._context = context;
            this._npoi = npoi;
        }
        public async Task<Result> Handle(UploadEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.file == null)
                return Result.Failure(new Error("404", " الملف غير موجود "));

            var tempPath = await CopyFile(request.file.File);
            DataTable dt = _npoi.ReadFile(tempPath, "Sheet1");
            var emps = DataTableToEntityAsync(dt, request.file, cancellationToken);
            await _context.EmployeeRepo.InsertEmployees(emps);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        private List<EmployeeModel> DataTableToEntityAsync(DataTable dt, EmployeeFileUploadDto request, CancellationToken cancellationToken)
        {
            List<EmployeeModel> Employees = new List<EmployeeModel>();

            // var maxId = _context.EmployeeRepo.GetQueryable().Max(t => t.Id) + 1;
            foreach (DataRow Row in dt.Rows)
            {
                if (_context.EmployeeRepo.GetQueryable().Any(t => t.NationalId == Row.ItemArray[5].ToString()))
                    continue;

                var employee = new EmployeeModel
                {

                    Name = Row.ItemArray[4].ToString(),
                    TegaraCode = Row.ItemArray[1].ToString(),
                    TabCode = Row.ItemArray[0].ToString(),
                    NationalId = Row.ItemArray[5].ToString(),
                    BankAccount = new EmployeeBankAccountModel()
                    {
                        AccountANumber = "بطاقات",
                        BankAId = 1,

                        AccountBNumber = "بطاقات",
                        BankBId = 1,
                        CreatedBy = _accessor.HttpContext.User.FindFirstValue("UUID"),
                        CteaedAt = DateTime.UtcNow.ToLocalTime(),

                    },
                    Collage = request.Collage,
                    Qanon = request.Qanon,
                    Position = EmployeePositionEnum.Employee
                };

                Employees.Add(employee);


            }


            return Employees;

            // await _context.EmployeeRepo.InsertEmployees(Employees);

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
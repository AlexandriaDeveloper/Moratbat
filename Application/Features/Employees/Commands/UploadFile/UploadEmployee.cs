using Application.Common.Messaging;
using Application.Common;
using MediatR;
using Application.Services;
using Microsoft.AspNetCore.Http;
using System.Data;
using Domain;
using Domain.Constants;
using Persistence;
using Domain.Interfaces.Repository;
using Application.Features.Employees.Queries.GetEmployees;

namespace Application.Features.Employees.Commands.UploadFile
{
    public record UploadEmployeeCommand(EmployeeFileUploadDto file) : ICommand;
    public class UploadEmployeeCommandHandler : ICommandHandler<UploadEmployeeCommand>
    {
        private readonly INPOIService _npoi;
        private readonly IUOW _context;

        public UploadEmployeeCommandHandler(INPOIService npoi, IUOW context)
        {
            this._context = context;
            this._npoi = npoi;
        }
        public async Task<Result> Handle(UploadEmployeeCommand request, CancellationToken cancellationToken)
        {
            if (request.file == null)
                return Result.Failure(new Error("404", " الملف غير موجود "));

            var tempPath = await CopyFile(request.file.File);
            DataTable dt = _npoi.ReadFile(tempPath, "Sheet1");
            await DataTableToEntityAsync(dt, request.file);
            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }

        private async Task<List<EmployeeModel>> DataTableToEntityAsync(DataTable dt, EmployeeFileUploadDto request)
        {

            List<EmployeeModel> Employees = new List<EmployeeModel>();
            foreach (DataRow Row in dt.Rows)
            {
                if (_context.EmployeeRepo.GetQueryable().Any(t => t.NationalId == Row.ItemArray[5].ToString()))
                    continue;
                var employee = new EmployeeModel();
                employee.Name = Row.ItemArray[4].ToString();
                employee.TegaraCode = Row.ItemArray[1].ToString();
                employee.TabCode = Row.ItemArray[0].ToString();
                employee.NationalId = Row.ItemArray[5].ToString();
                if (Row.ItemArray[3].ToString() == "بطاقة")
                {
                    employee.PaymentMethodA = PaymentMethodEnum.Atm;
                }
                else
                {
                    employee.PaymentMethodA = PaymentMethodEnum.BankTransfer;
                }
                employee.Collage = request.Collage;
                employee.Qanon = request.Qanon;
                employee.Position = EmployeePositionEnum.Employee;
                Employees.Add(employee);
            }
            await _context.EmployeeRepo.InsertEmployees(Employees);

            return Employees;

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
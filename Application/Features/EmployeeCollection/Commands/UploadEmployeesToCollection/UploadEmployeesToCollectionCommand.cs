
using System.Data;
using Application.Common;
using Application.Common.Messaging;
using Application.Constants;
using Application.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace Application.Features.EmployeeCollection.Commands.UploadEmployeesToCollection
{
    public record UploadEmployeesToCollectionCommand(FileToUploadDto file) : ICommand;
    public class UploadEmployeesToCollectionCommandHandler : ICommandHandler<UploadEmployeesToCollectionCommand>
    {
        private readonly IUOW _uOW;
        private readonly IMapper _mapper;
        private readonly INPOIService _npoi;
        public UploadEmployeesToCollectionCommandHandler(IUOW uOW, IMapper mapper, INPOIService npoi)
        {
            this._npoi = npoi;
            this._uOW = uOW;
            this._mapper = mapper;

        }
        public async Task<Result> Handle(UploadEmployeesToCollectionCommand request, CancellationToken cancellationToken)
        {
            if (request.file == null)
                return Result.Failure(new Error("404", " الملف غير موجود "));

            var tempPath = await CopyFile(request.file.File);
            DataTable dt = _npoi.ReadFile(tempPath, "Sheet1");
            var result = await ReadEmployeesFromTable(dt, request.file.CollectionId, cancellationToken);
            await _uOW.SaveChangesAsync(cancellationToken);
            return result;
        }
        private async Task<Result> ReadEmployeesFromTable(DataTable dt, int collectionId, CancellationToken cancellationToken)
        {
            foreach (DataRow row in dt.Rows)
            {
                var code = row.ItemArray[0].ToString();
                if (string.IsNullOrEmpty(code))
                {
                    return Result.Failure(new Error("404", "لا يمكن ترك الكود خالى "));
                }
                code = code.Replace(" ", "").Trim();
                var employeeid = _uOW.EmployeeRepo.GetQueryable().FirstOrDefault(x => x.TegaraCode == code);
                if (employeeid == null)
                {
                    return Result.Failure(new Error("404", $"عفوا الكود رقم {code} غير موجود")); ;
                }
                await _uOW.EmployeeCollectionRepo.Insert(new EmployeeCollectionModel
                {
                    CollectionId = collectionId,
                    EmployeeId = employeeid.Id,
                    IsActive = true
                }, cancellationToken);

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
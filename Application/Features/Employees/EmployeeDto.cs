using Domain.Constants;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Employees.Queries.GetEmployees
{
    public class EmployeeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string NationalId { get; set; }
        public string TabCode { get; set; }
        public string TegaraCode { get; set; }
        public string Collage { get; set; }
        public string Qanon { get; set; }
        public int? GradeId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

    }

    public class EmployeeFileUploadDto
    {
        public IFormFile File { get; set; }
        public string Position { get; set; }
        public string Collage { get; set; }
        public QanonEnum Qanon { get; set; }
    }
}
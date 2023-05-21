using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Features.EmployeeGrade
{
    public class EmployeeGradeDto
    {
        public int EmployeeId { get; set; }
        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime? EndAt { get; set; }
    }
    public class GradeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
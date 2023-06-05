namespace Persistence.Constants.Param
{
    public class EmployeeGradeParam
    {
        public int? EmployeeId { get; set; }
        public int? GradeId { get; set; }

        public int? ParentId { get; set; }
        public bool? ParentOnly { get; set; }

        public DateTime? StartFrom { get; set; }
        public DateTime? EndAt { get; set; }
    }
}
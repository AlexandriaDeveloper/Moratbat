using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;

namespace Domain
{
    public class GradeModel : BaseEntityModel
    {

        public int? ParentId { get; set; }
        public QanonEnum? Qanon { get; set; }
        public virtual ICollection<EmployeeGradeModel>? Employees { get; set; }
        public virtual GradeModel? Parent { get; set; }
    }
}
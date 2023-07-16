using System.ComponentModel.DataAnnotations.Schema;
using Domain.Constants;

namespace Domain.Models
{
#nullable enable
    public class GradeModel : BaseEntityModel
    {

        public int? ParentId { get; set; }
        public QanonEnum? Qanon { get; set; }
        [NotMapped]
        public bool HasParent => this.ParentId.HasValue ? true : false;
        public virtual ICollection<EmployeeGradeModel>? Employees { get; set; }
        public virtual GradeModel? Parent { get; set; }
    }

}
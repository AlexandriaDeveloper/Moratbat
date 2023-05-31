using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable enable
namespace Domain
{
    [Table("EmployeeGrade")]
    public class EmployeeGradeModel : BaseEntityModel
    {
        [NotMapped]
        public override int Id { get => base.Id; set => base.Id = value; }
        [NotMapped]
        public override string Name { get => base.Name; set => base.Name = value; }
        [Key]
        public int EmployeeId { get; set; }
        [Key]
        public int GradeId { get; set; }
        public DateTime StartFrom { get; set; }
        public DateTime? EndAt { get; set; }
        [NotMapped]
        public bool IsActive => EndAt.HasValue ? false : true;



        public EmployeeModel? Employee { get; set; }
        public GradeModel? Grade { get; set; } = null;
    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("EmployeeVacation")]
    public class EmployeeVacationModel : BaseEntityModel
    {
        [NotMapped]
        override public string Name { get; set; }
        public int EmployeeId { get; set; }
        public int VacationTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string Details { get; set; }
        public EmployeeModel Employee { get; set; }
        public VacationTypeModel VacationType { get; set; }
    }


    [Table("VacationType")]
    public class VacationTypeModel : BaseEntityModel
    {
        public ICollection<EmployeeVacationModel> EmployeeVacations { get; set; }
    }
}
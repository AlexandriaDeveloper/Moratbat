using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("EmployeeCollection")]
    public class EmployeeCollectionModel : BaseEntityModel
    {
        [NotMapped]
        override public string Name { get; set; }
        public int EmployeeId { get; set; }
        public int CollectionId { get; set; }
        public bool IsActive { get; set; } = true;
        public CollectionModel? Collection { get; set; }
        public EmployeeModel? Employee { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("Collection")]
    public class CollectionModel : BaseEntityModel
    {

        public List<EmployeeCollectionModel>? EmployeeCollection { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("EmployeePartTime")]
    public class EmployeePartTimeModel : BaseEntityModel
    {
        [NotMapped]
        override public string Name { get; set; }

        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool InPartTime => EndDate.HasValue == false;
        public string Details { get; set; }

        public EmployeeModel Employee { get; set; }
    }
}
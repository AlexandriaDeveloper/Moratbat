
using System.ComponentModel.DataAnnotations.Schema;
using Domain;
using Domain.Constants;

namespace Domain.Models
{

    [Table("AccountTreeDetails")]
    public class AccountTreeDetailsModel : BaseEntityModel
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        override public int Id { get; set; }
        public int AccountTreeId { get; set; }
        public AccountTreeModel AccountTree { get; set; }
    }


}

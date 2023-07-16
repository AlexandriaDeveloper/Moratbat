using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("AccountsTree")]
    public class AccountTreeModel : BaseEntityModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        override public int Id { get; set; }
        public int? AccountParentId { get; set; }

        public AccountTreeModel AccountParent { get; set; }
        public List<AccountTreeModel> AccountChilds { get; set; }

        public List<AccountTreeDetailsModel> AccountTreeDetails { get; set; } = new List<AccountTreeDetailsModel>();
    }
}
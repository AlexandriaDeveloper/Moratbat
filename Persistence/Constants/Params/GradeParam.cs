using Domain.Constants;

namespace Persistence.Constants.Param
{
    public class GradeParam
    {
        public bool? OnlyParent { get; set; }
        public int? GradeId { get; set; }
        public int? ParentId { get; set; }
        public string? Name { get; set; }
        public QanonEnum? Qanon { get; set; }


    }
}
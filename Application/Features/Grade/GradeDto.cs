using Domain.Constants;

namespace Application.Features.Grade.Queries.GetGradeById
{
    public class GradeDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public int? ParentId { get; set; }
    }
}
namespace Application.Features.EmployeeCollection.Commands.AddEmployeeToCollection
{

    public class EmployeeInCollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TabCode { get; set; }
        public string TegaraCode { get; set; }
        public string NationalId { get; set; }
        public bool IsActive { get; set; }
    }
    public class AddEmployeeToCollectionRequest
    {
        public int CollectionId { get; set; }
        public int EmployeeId { get; set; }
        public bool IsActive { get; set; }
    }
}
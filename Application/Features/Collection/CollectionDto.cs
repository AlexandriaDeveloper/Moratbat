namespace Application.Features.Collection.Queries.GetCollictions
{
    public class CollectionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
    }

    public class CopyCollectionRequest
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
    }
}


public class EmployeeCollectionConfiguration : IEntityTypeConfiguration<EmployeeCollectionModel>
{

    public void Configure(EntityTypeBuilder<EmployeeCollectionModel> builder)
    {
        builder.HasIndex(x => new { x.CollectionId, x.EmployeeId }).IsUnique();
    }
}

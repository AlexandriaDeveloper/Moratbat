

public class EmployeeGradeConfiguration : IEntityTypeConfiguration<EmployeeGradeModel>
{

    public void Configure(EntityTypeBuilder<EmployeeGradeModel> builder)
    {
        builder.HasKey(x => new { x.EmployeeId, x.GradeId });
    }
}

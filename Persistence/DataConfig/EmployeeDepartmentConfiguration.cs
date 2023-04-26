
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeDepartmentConfiguration : IEntityTypeConfiguration<EmployeeDepartmentModel>
{

    public void Configure(EntityTypeBuilder<EmployeeDepartmentModel> builder)
    {
        builder.HasKey(x => new { x.EmployeeId, x.DepartmentId });
    }
}

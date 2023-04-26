
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class EmployeeBankConfiguration : IEntityTypeConfiguration<EmployeeBankAccountModel>
{

    public void Configure(EntityTypeBuilder<EmployeeBankAccountModel> builder)
    {
        builder.HasKey(x => new { x.EmployeeId, x.BankId });
    }
}
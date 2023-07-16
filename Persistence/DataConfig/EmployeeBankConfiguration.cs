
public class EmployeeBankConfiguration : IEntityTypeConfiguration<EmployeeBankAccountModel>
{

    public void Configure(EntityTypeBuilder<EmployeeBankAccountModel> builder)
    {
        // builder.HasKey(x => new { x.EmployeeId, x.BankId });
        //     builder
        //    .HasKey(x => x.EmployeeId);
        //     builder.HasOne(x => x.Employee).WithOne(x => x.BankAccount);

        builder.HasKey(x => new { x.EmployeeId });
        builder.HasOne(x => x.Employee)
        .WithOne(x => x.BankAccount)
        .HasForeignKey<EmployeeBankAccountModel>(x => x.EmployeeId);


        builder.HasOne(x => x.BankA).WithMany(x => x.EmployeesA).HasForeignKey(x => x.BankAId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(x => x.BankB).WithMany(x => x.EmployeesB).HasForeignKey(x => x.BankBId).OnDelete(DeleteBehavior.NoAction);

    }



}


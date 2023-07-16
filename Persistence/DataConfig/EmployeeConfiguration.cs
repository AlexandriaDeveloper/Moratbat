
public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeModel>
{

    public void Configure(EntityTypeBuilder<EmployeeModel> builder)
    {


        // builder.HasOne(x => x.BankAccount)
        // .WithOne(x => x.Employee)
        // .HasForeignKey<EmployeeBankAccountModel>(x => x.EmployeeId);





    }
}

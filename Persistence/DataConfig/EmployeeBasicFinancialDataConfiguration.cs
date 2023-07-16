using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence.DataConfig
{
    public class EmployeeBasicFinancialDataConfiguration : IEntityTypeConfiguration<EmployeeBasicFinancialDataModel>
    {
        public void Configure(EntityTypeBuilder<EmployeeBasicFinancialDataModel> builder)
        {

            // builder.HasKey(x => new { x.EmployeeId, x.AcountTreeDetailsId, x.AcountTreeDetailsAccountTreeId });
            builder.HasOne(x => x.AccountTreeDetails)
            .WithMany()
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

            builder
            .HasIndex(x => new { x.EmployeeId, x.AccountTreeDetailsAccountTreeId, x.AccountTreeDetailsId })
            .IsUnique();
        }
    }
}
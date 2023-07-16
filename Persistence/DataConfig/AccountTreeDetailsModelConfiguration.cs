
public class AccountTreeDetailsModelConfiguration : IEntityTypeConfiguration<AccountTreeDetailsModel>
{

    public void Configure(EntityTypeBuilder<AccountTreeDetailsModel> builder)
    {
        builder.Property(x => x.AccountTreeId).IsRequired();
        builder.HasKey(x => new { x.Id, x.AccountTreeId });
        builder.HasIndex(x => new { x.AccountTreeId, x.Id }).IsUnique();

        ;
    }
}

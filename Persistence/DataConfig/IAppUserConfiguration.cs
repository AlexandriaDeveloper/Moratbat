
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class IAppUserConfiguration : IEntityTypeConfiguration<AppUser>
{

    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(pImage => pImage.DisplayName).HasMaxLength(100).IsRequired();
        builder.Property(pImage => pImage.ProfileImage).HasMaxLength(300);
    }
}

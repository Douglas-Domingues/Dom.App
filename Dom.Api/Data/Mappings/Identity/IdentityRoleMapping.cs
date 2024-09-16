using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dom.Api.Data.Mappings.Identity;

public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole<long>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<long>> builder)
    {
        builder.ToTable("IdentityRole");
        builder.HasKey(ur => ur.Id);
        builder.HasIndex(ur => ur.NormalizedName).IsUnique();
        builder.Property(ur => ur.ConcurrencyStamp).IsConcurrencyToken();
        builder.Property(ur => ur.Name).HasMaxLength(256);
        builder.Property(ur => ur.NormalizedName).HasMaxLength(256);

    }
}

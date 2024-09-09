using Microsoft.EntityFrameworkCore;
using Dom.Lib.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dom.Api.Data.Mappings;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transactions");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title).IsRequired().HasColumnType("VARCHAR(75)");
        builder.Property(x => x.Description).IsRequired(false).HasColumnType("MEDIUMTEXT").HasDefaultValueSql("NULL");
        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.PaydAt).IsRequired(false).HasDefaultValueSql("NULL"); ;
        builder.Property(x => x.Type).IsRequired().HasColumnType("TINYINT");
        builder.Property(x => x.Amount).IsRequired().HasColumnType("DECIMAL");
        builder.Property(x => x.CategoryId).IsRequired().HasColumnType("BIGINT");
        builder.Property(x => x.UserId).IsRequired().HasColumnType("VARCHAR(36)");
    }
}

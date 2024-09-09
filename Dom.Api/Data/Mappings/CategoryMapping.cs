using Dom.Lib.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
// mapeamento feito pelo fluent mapping

namespace Dom.Api.Data.Mappings;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Title)
            .IsRequired()
            .HasColumnType("VARCHAR(75)");
        builder.Property(c => c.Description)
            .IsRequired(false)
            .HasColumnType("TEXT")
            .HasDefaultValueSql("NULL");
        builder.Property(c => c.UserId)
            .IsRequired()
            .HasColumnType("VARCHAR(36)");
    }
}
using Ambev.DeveloperEvaluation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Title).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Price).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(u => u.Description).IsRequired().HasMaxLength(500);
        builder.Property(u => u.Category).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Image).IsRequired().HasMaxLength(300);

        builder.OwnsOne<Rating>(p => p.Rating, ratingBuilder =>
        {
            ratingBuilder.Property(r => r.Rate).HasColumnName("Rate").HasColumnType("decimal(10,2)");
            ratingBuilder.Property(r => r.Count).HasColumnName("Count").HasColumnType("int");
        });
    }
}

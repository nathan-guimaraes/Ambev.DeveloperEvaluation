using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.ORM.Mapping;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(x => x.Id);
        builder.Property(u => u.Id).HasColumnType("uuid").HasDefaultValueSql("gen_random_uuid()");

        builder.Property(x => x.UserId).IsRequired().HasColumnType("uuid");
        builder.Property(x => x.Branch).IsRequired().HasMaxLength(100).HasDefaultValue(string.Empty);
        builder.Property(x => x.SaleDate).HasConversion<DateTime>().IsRequired().HasColumnType("timestamptz");
        builder.Property(x => x.TotalSaleAmount).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(x => x.TotalSaleDiscount).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(x => x.IsCanceled).IsRequired().HasColumnType("boolean");

        builder.OwnsMany(s => s.Items, builder =>
        {
            builder.ToTable("SaleItems");
            builder.Property(i => i.ProductId).IsRequired().HasColumnType("uuid");
            builder.Property(i => i.Quantity).IsRequired().HasColumnType("int");
            builder.Property(i => i.UnitPrice).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(i => i.TotalAmountWithDiscount).IsRequired().HasColumnType("decimal(10,2)");
            builder.Property(i => i.TotalSaleItemAmount).IsRequired().HasColumnType("decimal(10,2)");
        });
    }
}

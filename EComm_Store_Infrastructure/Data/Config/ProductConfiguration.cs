using EComm_Store_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EComm_Store_Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ID).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(60);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(p => p.PictureURL).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany()
                   .HasForeignKey(p => p.ProductBrandID);
            builder.HasOne(t => t.ProductType).WithMany()
                   .HasForeignKey(p => p.ProductTypeID);
        }
    }
}
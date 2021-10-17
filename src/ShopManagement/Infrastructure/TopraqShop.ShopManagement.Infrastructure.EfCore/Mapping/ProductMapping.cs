using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<ProductBase>
    {
        public void Configure(EntityTypeBuilder<ProductBase> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(hk => hk.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(200);
            builder.Property(p => p.Code).HasMaxLength(100);
            builder.Property(p => p.UnitPrice);
            builder.Property(p => p.IsInStock).IsRequired();
            builder.Property(p => p.ShortDescription).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Picture).IsRequired().HasMaxLength(256);
            builder.Property(p => p.PictureAlt).HasMaxLength(100);
            builder.Property(p => p.PictureTitle).HasMaxLength(100);
            builder.Property(p => p.Keywords).HasMaxLength(80);
            builder.Property(p => p.MetaDescription).HasMaxLength(150);
            builder.Property(p => p.Slug).HasMaxLength(300);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.Status).IsRequired();

            builder
                .HasOne(ho => ho.ProductCategoryBase)
                .WithMany(wm => wm.Products)
                .HasForeignKey(hf => hf.ProductCategoryId);


        }
    }
}
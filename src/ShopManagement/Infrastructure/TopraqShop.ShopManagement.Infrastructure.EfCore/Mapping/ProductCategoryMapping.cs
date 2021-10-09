using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductCategoryMapping:IEntityTypeConfiguration<ProductCategoryBase>
    {
        public void Configure(EntityTypeBuilder<ProductCategoryBase> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(hk => hk.Id);
            //builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Picture).IsRequired().HasMaxLength(256);
            builder.Property(p => p.PictureAlt).IsRequired().HasMaxLength(256);
            builder.Property(p => p.PictureTitle).IsRequired().HasMaxLength(256);
            builder.Property(p => p.Keywords).IsRequired().HasMaxLength(80);
            builder.Property(p => p.MetaDescription).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(300);
            builder.Property(p => p.CreatedOn).IsRequired();
            builder.Property(p => p.ModifiedOn).IsRequired();
            builder.Property(p => p.Status).IsRequired();
        }
    }
}
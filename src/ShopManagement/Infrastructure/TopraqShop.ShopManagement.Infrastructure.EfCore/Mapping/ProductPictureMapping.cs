using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Mapping
{
    public class ProductPictureMapping:IEntityTypeConfiguration<ProductPictureBase>
    {
        public void Configure(EntityTypeBuilder<ProductPictureBase> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(hk => hk.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Picture).IsRequired().HasMaxLength(256);
            builder.Property(p => p.PictureTitle).IsRequired().HasMaxLength(256);
            builder.Property(p => p.PictureAlt).IsRequired().HasMaxLength(256);

            builder.HasOne(ho => ho.ProductBase)
                .WithMany(wm => wm.ProductPictures)
                .HasForeignKey(hk => hk.ProductId);
        }
    }
}
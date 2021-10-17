using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TopraqShop.ShopManagement.Domain.Base.SlideAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Mapping
{
    public class SlideMapping:IEntityTypeConfiguration<SlideBase>
    {
        public void Configure(EntityTypeBuilder<SlideBase> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(hk => hk.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Picture).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.PictureTitle).IsRequired().HasMaxLength(500);
            builder.Property(p => p.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Heading).IsRequired().HasMaxLength(255);
            builder.Property(p => p.Title).HasMaxLength(255);
            builder.Property(p => p.Text).HasMaxLength(255);
            builder.Property(p => p.ButtonText).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Link).IsRequired().HasMaxLength(256);
        }
    }
}
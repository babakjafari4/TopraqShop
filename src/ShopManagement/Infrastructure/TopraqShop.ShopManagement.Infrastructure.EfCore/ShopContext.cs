using Microsoft.EntityFrameworkCore;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate;
using TopraqShop.ShopManagement.Infrastructure.EfCore.Mapping;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<ProductCategoryBase> ProductCategories { get; set; }
        public DbSet<ProductBase> Products { get; set; }
        public DbSet<ProductPictureBase> ProductPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
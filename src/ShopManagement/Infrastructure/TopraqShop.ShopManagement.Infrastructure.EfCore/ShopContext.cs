using Microsoft.EntityFrameworkCore;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using TopraqShop.ShopManagement.Infrastructure.EfCore.Mapping;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore
{
    public class ShopContext:DbContext
    {
        public ShopContext(DbContextOptions<ShopContext> dbContextOptions):base(dbContextOptions)
        {
        }

        public DbSet<ProductCategoryBase> ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
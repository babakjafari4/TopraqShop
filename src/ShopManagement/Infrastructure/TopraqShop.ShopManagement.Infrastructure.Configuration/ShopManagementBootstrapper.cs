using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TopraqShop.ShopManagement.Domain.Application.Base.Product;
using TopraqShop.ShopManagement.Domain.Application.Base.ProductCategory;
using TopraqShop.ShopManagement.Domain.Application.Base.ProductPicture;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Interface;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Interface;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Interface;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate;
using TopraqShop.ShopManagement.Infrastructure.EfCore;
using TopraqShop.ShopManagement.Infrastructure.EfCore.Repositories;

namespace TopraqShop.ShopManagement.Infrastructure.Configuration
{
    public class ShopManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            
            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();
            
            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();
            
            services.AddAutoMapper(typeof(ShopManagementBootstrapper));
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
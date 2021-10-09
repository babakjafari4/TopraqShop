using AutoMapper;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;

namespace TopraqShop.ShopManagement.Domain.Application.Base.ProductCategory
{
    public class ProductCategoryProfile:Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategoryBase, ProductCategoryViewModel>();
        }
    }
}
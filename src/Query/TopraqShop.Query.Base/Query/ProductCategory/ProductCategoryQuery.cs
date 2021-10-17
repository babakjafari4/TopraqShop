using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TopraqShop.Query.Base.Contracts.ProductCategory;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using TopraqShop.ShopManagement.Infrastructure.EfCore;

namespace TopraqShop.Query.Base.Query.ProductCategory
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<ProductCategoryQueryModel> GetSlides()
        {
            return _shopContext
                .ProductCategories
                .Where(w => w.Status != (byte) ProductCategoryStatus.Deleted)
                .Select(s =>
                    new ProductCategoryQueryModel
                    {
                        Picture = s.Picture,
                        Id = s.Id,
                        Name = s.Name,
                        PictureTitle = s.PictureTitle,
                        PictureAlt = s.PictureAlt,
                        Slug = s.Slug
                    })
                .OrderByDescending(o => o.Id)
                .ToList();
        }
    }
}
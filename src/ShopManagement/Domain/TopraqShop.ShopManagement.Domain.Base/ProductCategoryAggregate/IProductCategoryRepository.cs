using System.Collections.Generic;

namespace TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory productCategory);
        ProductCategory GetBy(byte id);
        List<ProductCategory> GetAll();
        int Commit();
    }
}
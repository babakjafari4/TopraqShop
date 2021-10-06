using System.Collections.Generic;

namespace TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategoryBase productCategoryBase);
        ProductCategoryBase GetBy(byte id);
        List<ProductCategoryBase> GetAll();
        int Commit();
    }
}
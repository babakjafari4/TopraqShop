using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategoryBase productCategoryBase);
        ProductCategoryBase GetBy(byte id);
        List<ProductCategoryBase> GetAll();
        int Commit();

        bool IsExists(Expression<Func<ProductCategoryBase, bool>> expression);
        ProductCategoryBase GetDetails(byte id);
    }
}
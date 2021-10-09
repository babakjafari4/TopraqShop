using System;
using TopraqShop.Framework.Base.Domain;

namespace TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate
{
    public interface IProductCategoryRepository:IRepository<byte, ProductCategoryBase>
    {
    }
}
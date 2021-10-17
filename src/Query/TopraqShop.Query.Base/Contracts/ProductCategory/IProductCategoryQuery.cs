using System.Collections.Generic;

namespace TopraqShop.Query.Base.Contracts.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQueryModel> GetSlides();
    }
}
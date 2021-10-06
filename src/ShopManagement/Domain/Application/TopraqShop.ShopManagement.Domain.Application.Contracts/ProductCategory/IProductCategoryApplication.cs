using System.Collections.Generic;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory
{
    public interface IProductCategoryApplication
    {
        int Create(CreateProductCategory createProductCategory);
        int Edit(EditProductCategory editProductCategory);
        int Delete(byte id);
        int Deactivate(byte id);
        int Activate(byte id);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel categorySearchModel);
        ProductCategoryBase GetBy(byte id);
    }
}
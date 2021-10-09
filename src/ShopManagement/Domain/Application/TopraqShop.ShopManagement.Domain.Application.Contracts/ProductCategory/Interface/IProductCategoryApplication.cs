using System.Collections.Generic;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Interface
{
    public interface IProductCategoryApplication
    {
        OperationResult Create(CreateProductCategory createProductCategory);
        OperationResult Edit(EditProductCategory editProductCategory);
        OperationResult Delete(byte id);
        OperationResult Deactivate(byte id);
        OperationResult Activate(byte id);
        List<ProductCategoryViewModel> GetAll();
        List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel);
        EditProductCategory GetDetails(byte id);
    }
}
using System.Collections.Generic;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Interface
{
    public interface IProductApplication
    {
        OperationResult Create(CreateProduct createProduct);
        OperationResult Edit(EditProduct editProductCategory);
        OperationResult HasInStock(long id);
        OperationResult HasNotInStock(long id);
        OperationResult Delete(long id);
        OperationResult Deactivate(long id);
        OperationResult Activate(long id);
        List<ProductViewModel> GetAll();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        EditProduct GetDetails(long id);
    }
}
using System.Collections.Generic;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Interface
{
    public interface IProductPictureApplication
    {
        OperationResult Create(CreateProductPicture createProduct);
        OperationResult Edit(EditProductPicture editProductCategory);
        OperationResult Delete(int id);
        OperationResult Deactivate(int id);
        OperationResult Activate(int id);
        List<ProductPictureViewModel> GetAll();
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
        EditProductPicture GetDetails(int id);
    }
}
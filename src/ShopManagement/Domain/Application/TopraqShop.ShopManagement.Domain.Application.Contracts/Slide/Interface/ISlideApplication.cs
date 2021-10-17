using System.Collections.Generic;
using TopraqShop.Framework.Base.Application;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Interface
{
    public interface ISlideApplication
    {
        OperationResult Create(CreateSlide createProduct);
        OperationResult Edit(EditSlide editSlide);
        OperationResult Delete(int id);
        OperationResult Deactivate(int id);
        OperationResult Activate(int id);
        List<SlideViewModel> GetAll();
        List<SlideViewModel> Search(SlideSearchModel searchModel);
        EditSlide GetDetails(int id);
    }
}
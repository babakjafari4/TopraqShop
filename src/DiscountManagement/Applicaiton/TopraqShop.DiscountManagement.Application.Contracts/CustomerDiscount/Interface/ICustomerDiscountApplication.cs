using System.Collections.Generic;
using TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Concrete;
using TopraqShop.Framework.Base.Application;

namespace TopraqShop.DiscountManagement.Application.Contracts.CustomerDiscount.Interface
{
    public interface ICustomerDiscountApplication
    {
        OperationResult Create(CreateCustomerDiscount command);
        OperationResult Edit(EditCustomerDiscount command);
        OperationResult Delete(long id);
        OperationResult Deactivate(long id);
        OperationResult Activate(long id);
        List<CustomerDiscountViewModel> GetAll();
        List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel);
        EditCustomerDiscount GetDetails(long id);
    }
}
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Interface;

namespace TopraqShop.Presentation.ServiceHost.Areas.Administration.Pages.ShopManagement.ProductCategories
{
    public class IndexModel : PageModel
    {
        public ProductCategorySearchModel SearchModel;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        public IndexModel(IProductCategoryApplication productCategoryApplication)
        {
            _productCategoryApplication = productCategoryApplication;
        }
        public void OnGet(ProductCategorySearchModel searchModel)
        {
            ProductCategories = _productCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateProductCategory());
        }
        public IActionResult OnPostCreate(CreateProductCategory command)
        {
            var result = _productCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(byte id)
        {
            var editProductCategory = _productCategoryApplication.GetDetails(id);
            return Partial("./Edit", editProductCategory);
        }

        public IActionResult OnPostEdit(EditProductCategory productCategory)
        {
            var operationResult = _productCategoryApplication.Edit(productCategory);
            return new JsonResult(operationResult);
        }
    }
}
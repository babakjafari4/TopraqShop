using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Interface;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Interface;

namespace TopraqShop.Presentation.ServiceHost.Areas.Administration.Pages.ShopManagement.Products
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        public ProductSearchModel SearchModel { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public SelectList ProductCategories { get; set; }

        public IndexModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
        }

        public void OnGet(ProductSearchModel searchModel)
        {
            Products = _productApplication.Search(searchModel);
            ProductCategories = new SelectList(_productCategoryApplication.GetAll(), "Id", "Name");
        }


        public IActionResult OnGetCreate()
        {
            return Partial("Create",
                new CreateProduct {ProductCategories = _productCategoryApplication.GetAll()});
        }


        public IActionResult OnPostCreate(CreateProduct command)
        {
            try
            {
                var operationResult = _productApplication.Create(command);
                if (operationResult.IsSucceeded)
                    return RedirectToPage("./Index");

                Message = operationResult.Message;
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Message = $"Message: {e.Message}, and inner exception: {e.InnerException}";
                return RedirectToPage("./Index");
            }
        }


        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.ProductCategories = _productCategoryApplication.GetAll();
            return Partial("./Edit", product);
        }

        public IActionResult OnPostEdit(EditProduct product)
        {
            try
            {
                var operationResult = _productApplication.Edit(product);
                if (operationResult.IsSucceeded)
                    return RedirectToPage("./Index");

                Message = operationResult.Message;
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Message = $"Message: {e.Message}, and inner exception: {e.InnerException}";
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnGetDelete(long id)
        {
            try
            {
                var operationResult = _productApplication.Delete(id);
                if (operationResult.IsSucceeded)
                    return RedirectToPage("./Index");
                Message = operationResult.Message;
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Message = $"Message: {e.Message}, and inner exception: {e.InnerException}";
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnGetHasNotInStock(long id)
        {
            try
            {
                var operationResult = _productApplication.HasNotInStock(id);
                if (operationResult.IsSucceeded)
                    return RedirectToPage("./Index");
                Message = operationResult.Message;
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Message = $"Message: {e.Message}, and inner exception: {e.InnerException}";
                return RedirectToPage("./Index");
            }
        }

        public IActionResult OnGetHasInStock(long id)
        {
            try
            {
                var operationResult = _productApplication.HasInStock(id);
                if (operationResult.IsSucceeded)
                    return RedirectToPage("./Index");
                Message = operationResult.Message;
                return RedirectToPage("./Index");
            }
            catch (Exception e)
            {
                Message = $"Message: {e.Message}, and inner exception: {e.InnerException}";
                return RedirectToPage("./Index");
            }
        }
    }
}
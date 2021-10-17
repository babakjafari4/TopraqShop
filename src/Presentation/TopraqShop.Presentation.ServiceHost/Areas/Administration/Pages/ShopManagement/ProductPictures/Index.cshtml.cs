using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Interface;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Interface;

namespace TopraqShop.Presentation.ServiceHost.Areas.Administration.Pages.ShopManagement.ProductPictures
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;
        [TempData] public string Message { get; set; }
        public ProductPictureSearchModel SearchModel { get; set; }
        public List<ProductPictureViewModel> ProductPictures { get; set; }
        public List<ProductViewModel> Products { get; set; }

        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            ProductPictures = _productPictureApplication.Search(searchModel);
            Products = _productApplication.GetAll();
        }


        public IActionResult OnGetCreate()
        {
            return Partial("Create", 
                new CreateProductPicture {Products = _productApplication.GetAll()});
        }


        public IActionResult OnPostCreate(CreateProductPicture command)
        {
            try
            {
                var operationResult = _productPictureApplication.Create(command);
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


        public IActionResult OnGetEdit(int id)
        {
            var product = _productPictureApplication.GetDetails(id);
            product.Products = _productApplication.GetAll();
            return Partial("./Edit", product);
        }

        public IActionResult OnPostEdit(EditProductPicture productPicture)
        {
            try
            {
                var operationResult = _productPictureApplication.Edit(productPicture);
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

        public IActionResult OnGetDelete(int id)
        {
            try
            {
                var operationResult = _productPictureApplication.Delete(id);
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
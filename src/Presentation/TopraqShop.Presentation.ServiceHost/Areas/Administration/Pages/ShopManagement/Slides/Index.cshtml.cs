using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Concrete;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Interface;

namespace TopraqShop.Presentation.ServiceHost.Areas.Administration.Pages.ShopManagement.Slides
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;
        [TempData] public string Message { get; set; }
        public SlideSearchModel SearchModel { get; set; }
        public List<SlideViewModel> Slides { get; set; }

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Slides = _slideApplication.GetAll();
        }


        public IActionResult OnGetCreate()
        {
            return Partial("Create", new CreateSlide());
        }


        public IActionResult OnPostCreate(CreateSlide command)
        {
            try
            {
                var operationResult = _slideApplication.Create(command);
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
            var slide = _slideApplication.GetDetails(id);
            return Partial("./Edit", slide);
        }

        public IActionResult OnPostEdit(EditSlide slide)
        {
            try
            {
                var operationResult = _slideApplication.Edit(slide);
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
                var operationResult = _slideApplication.Delete(id);
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
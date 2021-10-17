using Microsoft.AspNetCore.Mvc;
using TopraqShop.Query.Base.Contracts.Slide;

namespace TopraqShop.Presentation.ServiceHost.ViewComponents
{
    public class SlideViewComponent:ViewComponent
    {
        private readonly ISlideQuery _slideQuery;

        public SlideViewComponent(ISlideQuery slideQuery)
        {
            _slideQuery = slideQuery;
        }
        public IViewComponentResult Invoke()
        {
            var heroSlideQueryModels = _slideQuery.GetSlides();
            return View(heroSlideQueryModels);
        }
    }
}
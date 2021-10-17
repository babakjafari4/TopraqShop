using Microsoft.AspNetCore.Mvc;
using TopraqShop.Query.Base.Contracts.ProductCategory;

namespace TopraqShop.Presentation.ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent:ViewComponent
    {
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;
        }
        public IViewComponentResult Invoke()
        {
            var productCategoryQueryModels = _productCategoryQuery.GetSlides();
            return View(productCategoryQueryModels);
        }
    }
}
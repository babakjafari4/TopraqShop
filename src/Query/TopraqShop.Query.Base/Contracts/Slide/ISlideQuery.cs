using System.Collections.Generic;

namespace TopraqShop.Query.Base.Contracts.Slide
{
    public interface ISlideQuery
    {
        List<HeroSlideQueryModel> GetSlides();
    }
}
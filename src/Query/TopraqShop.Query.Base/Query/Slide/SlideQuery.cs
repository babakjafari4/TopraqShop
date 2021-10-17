using System.Collections.Generic;
using System.Linq;
using TopraqShop.Query.Base.Contracts.Slide;
using TopraqShop.ShopManagement.Domain.Base.SlideAggregate;
using TopraqShop.ShopManagement.Infrastructure.EfCore;

namespace TopraqShop.Query.Base.Query.Slide
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext _shopContext;

        public SlideQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }

        public List<HeroSlideQueryModel> GetSlides()
        {
            return _shopContext
                .Slides
                .Where(w => w.Status != (int) SlideStatus.Deleted)
                .Select(s =>
                    new HeroSlideQueryModel(s.Picture, s.PictureAlt, s.PictureTitle, s.Heading, s.Title, s.Text,
                        s.ButtonText, s.Link))
                .ToList();
        }
    }
}
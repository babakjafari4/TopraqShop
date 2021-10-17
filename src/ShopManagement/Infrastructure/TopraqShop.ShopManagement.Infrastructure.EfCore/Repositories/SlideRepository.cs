using TopraqShop.Framework.Base.Infrastructure;
using TopraqShop.ShopManagement.Domain.Base.SlideAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Repositories
{
    public class SlideRepository:RepositoryBase<int, SlideBase>, ISlideRepository
    {
        public SlideRepository(ShopContext shopContext) : base(shopContext)
        {
        }
    }
}
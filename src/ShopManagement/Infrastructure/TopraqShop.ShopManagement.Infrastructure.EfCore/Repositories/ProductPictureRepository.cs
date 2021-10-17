using Microsoft.EntityFrameworkCore;
using TopraqShop.Framework.Base.Infrastructure;
using TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductPictureRepository:RepositoryBase<int, ProductPictureBase>, IProductPictureRepository
    {
        public ProductPictureRepository(ShopContext dbContext) : base(dbContext)
        {
        }
    }
}
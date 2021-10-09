using TopraqShop.Framework.Base.Infrastructure;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;

namespace TopraqShop.ShopManagement.Infrastructure.EfCore.Repositories
{
    public class ProductCategoryRepository : RepositoryBase<int, ProductCategoryBase>, IProductCategoryRepository
    {
        private readonly ShopContext _shopContext;

        public ProductCategoryRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
    }
}
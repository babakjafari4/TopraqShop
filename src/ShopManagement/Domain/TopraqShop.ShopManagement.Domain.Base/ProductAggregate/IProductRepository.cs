using TopraqShop.Framework.Base.Domain;

namespace TopraqShop.ShopManagement.Domain.Base.ProductAggregate
{
    public interface IProductRepository:IRepository<long, ProductBase>
    {
        
    }
}
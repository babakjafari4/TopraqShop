using TopraqShop.Framework.Base.Domain;

namespace TopraqShop.DiscountManagement.Domain.Base.CustomerDiscountAggregate
{
    public interface ICustomerDiscountRepository : IRepository<long, CustomerDiscountBase>
    {
    }
}
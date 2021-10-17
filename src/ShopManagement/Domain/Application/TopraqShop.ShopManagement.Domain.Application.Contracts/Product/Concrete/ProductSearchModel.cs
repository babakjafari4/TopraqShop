namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete
{
    public class ProductSearchModel
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int CategoryId { get; set; }
    }
}
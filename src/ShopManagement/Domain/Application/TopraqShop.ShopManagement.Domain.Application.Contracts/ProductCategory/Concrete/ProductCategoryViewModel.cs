namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete
{
    public class ProductCategoryViewModel
    {
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public int ProductsCount { get; set; }
    }
}
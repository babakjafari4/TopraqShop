namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get;  set; }
        public string Code { get;  set; }
        public double UnitPrice { get;  set; }
        public bool IsInStock { get;  set; }
        public string Picture { get;  set; }
        public string Slug { get;  set; }
        public int CategoryId { get; set; }
        public string CategoryIdName { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }


        public ProductViewModel(long id, string name, string code, double unitPrice, bool isInStock, string picture, string slug, string categoryIdName,int categoryId, string createdOn, string modifiedOn)
        {
            Id = id;
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            IsInStock = isInStock;
            Picture = picture;
            Slug = slug;
            CategoryIdName = categoryIdName;
            CategoryId = categoryId;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
        }
    }
}
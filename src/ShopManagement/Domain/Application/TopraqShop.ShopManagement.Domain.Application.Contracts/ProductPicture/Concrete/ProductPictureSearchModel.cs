namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete
{
    public class ProductPictureSearchModel
    {
        public long ProductId { get; set; }
        public string PictureTitle { get; set; }
        public string PictureAlt { get; set; }
    }
}
namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete
{
    public class ProductPictureViewModel
    {
        public int Id { get; set; }
        public long ProductId { get; private set; }
        public string ProductIdName { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string Status { get; set; }

        public ProductPictureViewModel(int id, string productIdName, long productId, string picture, string pictureAlt, string pictureTitle, string createdOn, string modifiedOn, string status)
        {
            Id = id;
            ProductIdName = productIdName;
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Status = status;
        }
    }
}
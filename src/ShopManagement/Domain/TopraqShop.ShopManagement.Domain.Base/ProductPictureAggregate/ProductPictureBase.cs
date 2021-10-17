using System;
using TopraqShop.Framework.Base.Domain;
using TopraqShop.ShopManagement.Domain.Base.ProductAggregate;

namespace TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate
{
    public class ProductPictureBase : EntityBase<int>
    {
        public long ProductId { get; private set; }
        public ProductBase ProductBase { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }

        public ProductPictureBase(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;

            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            Status = (byte) ProductPictureStatus.Draft;
            CheckInvariants();
        }

        public void Edit(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId = productId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;

            ModifiedOn = DateTime.Now;
            CheckInvariants();
        }

        public void Delete()
        {
            Status = (byte) ProductPictureStatus.Deleted;
            ModifiedOn = DateTime.Now;
        }

        public void Activate()
        {
            Status = (byte) ProductPictureStatus.Active;
            ModifiedOn = DateTime.Now;
        }

        public void Deactivate()
        {
            Status = (byte) ProductPictureStatus.Inactive;
            ModifiedOn = DateTime.Now;
        }

        public void CheckInvariants()
        {
            if (ProductId == 0)
                throw new NullReferenceException($"{nameof(ProductId)} Should be selected!");
            if (string.IsNullOrWhiteSpace(Picture))
                throw new NullReferenceException($"{nameof(Picture)} cannot be null!");
            if (string.IsNullOrWhiteSpace(PictureAlt))
                throw new NullReferenceException($"{nameof(PictureAlt)} cannot be null!");
            if (string.IsNullOrWhiteSpace(PictureTitle))
                throw new NullReferenceException($"{nameof(PictureTitle)} cannot be null!");
        }
    }
}
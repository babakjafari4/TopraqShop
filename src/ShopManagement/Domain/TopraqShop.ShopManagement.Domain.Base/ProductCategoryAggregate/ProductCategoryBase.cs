using System;
using TopraqShop.Framework.Base.Domain;

namespace TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate
{
    public class ProductCategoryBase : EntityBase<byte>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }

        public ProductCategoryBase(string name, string description, string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;

            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            Status = (byte) ProductCategoryStatus.Draft;

            CheckInvariants();
        }

        public void Edit(string name, string description, string picture, string pictureAlt, string pictureTitle,
            string keywords, string metaDescription, string slug)
        {
            Name = name;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;

            ModifiedOn = DateTime.Now;

            CheckInvariants();
        }

        public void Activate()
        {
            Status = (byte) ProductCategoryStatus.Active;
            ModifiedOn = DateTime.Now;

            CheckInvariants();
        }

        public void Deactivate()
        {
            Status = (byte) ProductCategoryStatus.Inactive;
            ModifiedOn = DateTime.Now;

            CheckInvariants();
        }

        public void Delete()
        {
            Status = (byte) ProductCategoryStatus.Deleted;
            ModifiedOn = DateTime.Now;

            CheckInvariants();
        }

        private void CheckInvariants()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new NullReferenceException($"{nameof(Name)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Description))
                throw new NullReferenceException($"{nameof(Description)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Picture))
                throw new NullReferenceException($"{nameof(Picture)} cannot be null!");
            if (string.IsNullOrWhiteSpace(PictureAlt))
                throw new NullReferenceException($"{nameof(PictureAlt)} cannot be null!");
            if (string.IsNullOrWhiteSpace(PictureTitle))
                throw new NullReferenceException($"{nameof(PictureTitle)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Keywords))
                throw new NullReferenceException($"{nameof(Keywords)} cannot be null!");
            if (string.IsNullOrWhiteSpace(MetaDescription))
                throw new NullReferenceException($"{nameof(MetaDescription)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Slug))
                throw new NullReferenceException($"{nameof(Slug)} cannot be null!");
        }
    }
}
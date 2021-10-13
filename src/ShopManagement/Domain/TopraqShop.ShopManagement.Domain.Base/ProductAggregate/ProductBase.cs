using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TopraqShop.Framework.Base.Domain;
using TopraqShop.ShopManagement.Domain.Base.ProductCategoryAggregate;
using TopraqShop.ShopManagement.Domain.Base.ProductPictureAggregate;

namespace TopraqShop.ShopManagement.Domain.Base.ProductAggregate
{
    public class ProductBase : EntityBase<long>
    {
        public string Name { get; private set; }
        public string Code { get; private set; }
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get;private set; }
        public string Slug { get; private set; }


        public int ProductCategoryId { get; private set; }
        public ProductCategoryBase ProductCategoryBase { get; private set; }

        public List<ProductPictureBase> ProductPictures { get; set; }

        public ProductBase(
            string name,
            string code,
            double unitPrice,
            string shortDescription,
            string description,
            string picture,
            string pictureAlt,
            string pictureTitle,
            string keywords,
            string metaDescription,
            string slug, int productCategoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            ProductCategoryId = productCategoryId;

            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            Status = (byte) ProductStatus.Draft;

            CheckInvariants();
        }

        public void Edit(string name,
            string code,
            double unitPrice,
            string shortDescription,
            string description,
            string picture,
            string pictureAlt,
            string pictureTitle,
            string keywords,
            string metaDescription,
            string slug,
            int categoryId)
        {
            Name = name;
            Code = code;
            UnitPrice = unitPrice;
            ShortDescription = shortDescription;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
            ProductCategoryId = categoryId;

            ModifiedOn = DateTime.Now;
            CheckInvariants();
        }

        public void HasInStock()
        {
            IsInStock = true;
            ModifiedOn = DateTime.Now;
        }

        public void HasNotInStock()
        {
            IsInStock = false;
            ModifiedOn = DateTime.Now;
        }

        public void Delete()
        {
            Status = (byte) ProductStatus.Deleted;
            ModifiedOn = DateTime.Now;
        }

        public void Activate()
        {
            Status = (byte) ProductStatus.Active;
            ModifiedOn = DateTime.Now;
        }

        public void Deactivate()
        {
            Status = (byte) ProductStatus.Inactive;
            ModifiedOn = DateTime.Now;
        }

        private void CheckInvariants()
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new NullReferenceException($"{nameof(Name)} cannot be null!");
            if (string.IsNullOrWhiteSpace(ShortDescription))
                throw new NullReferenceException($"{nameof(ShortDescription)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Description))
                throw new NullReferenceException($"{nameof(Description)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Picture))
                throw new NullReferenceException($"{nameof(Picture)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Slug))
                throw new NullReferenceException($"{nameof(Slug)} cannot be null!");

            if (CreatedOn > ModifiedOn)
                throw new ValidationException($"{nameof(CreatedOn)} cannot be greater then {nameof(ModifiedOn)}!");
        }
    }
}
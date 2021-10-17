using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete
{
    public class EditProduct
    {
        [Required] public long Id { get; set; }

        [Required, MinLength(3), MaxLength(200)]
        public string Name { get; set; }

        public string Code { get; set; }
        public double UnitPrice { get; set; }

        [Required, MinLength(3), MaxLength(250)]
        public string ShortDescription { get; set; }

        [Required, MinLength(3), MaxLength(1000)]
        public string Description { get; set; }

        [Required, MinLength(10), MaxLength(256)]
        public string Picture { get; set; }

        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Slug { get; set; }

        [Range(1, 100_000)] public int ProductCategoryId { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; }

        public EditProduct()
        {
        }

        public EditProduct(long id, string name, string code, double unitPrice, string shortDescription,
            string description, string picture, string pictureAlt, string pictureTitle, string keywords,
            string metaDescription, string slug, int productCategoryId)
        {
            Id = id;
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

            ProductCategories = new List<ProductCategoryViewModel>();
        }
    }
}
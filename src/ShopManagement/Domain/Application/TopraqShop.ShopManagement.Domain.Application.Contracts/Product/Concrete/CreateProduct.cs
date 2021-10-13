using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete
{
    public class CreateProduct
    {
        [Required, MinLength(3), MaxLength(200)]
        public string Name { get;  set; }

        public string Code { get;  set; }
        public double UnitPrice { get;  set; }
        
        [Required, MinLength(3), MaxLength(250)]
        public string ShortDescription { get;  set; }

        [Required, MinLength(3), MaxLength(1000)]
        public string Description { get;  set; }

        [Required, MinLength(10), MaxLength(256)]
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Keywords { get;  set; }
        public string MetaDescription { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string Slug { get;  set; }

        [Range(1, 100_000)] public int CategoryId { get; set; }

        public List<ProductCategoryViewModel> ProductCategories { get; set; }
    }
}
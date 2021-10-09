using System.ComponentModel.DataAnnotations;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductCategory.Concrete
{
    public class EditProductCategory
    {
        public int Id { get; set; }
        
        [Required, MinLength(3), MaxLength(100)]
        public string Name { get; set; }

        [Required, MinLength(3), MaxLength(500)]
        public string Description { get; set; }

        [Required, MinLength(3), MaxLength(256)]
        public string Picture { get; set; }

        [Required, MinLength(3), MaxLength(256)]
        public string PictureAlt { get; set; }

        [Required, MinLength(3), MaxLength(256)]
        public string PictureTitle { get; set; }

        [Required, MinLength(3), MaxLength(80)]
        public string Keywords { get; set; }

        [Required, MinLength(3), MaxLength(150)]
        public string MetaDescription { get; set; }

        [Required, MinLength(3), MaxLength(300)]
        public string Slug { get; set; }
    }
}
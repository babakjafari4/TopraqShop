using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TopraqShop.ShopManagement.Domain.Application.Contracts.Product.Concrete;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.ProductPicture.Concrete
{
    public class CreateProductPicture
    {
        [Range(1, 100_000)] 
        public long ProductId { get;  set; }

        [Required, MinLength(10), MaxLength(256)]
        public string Picture { get;  set; }

        [Required, MinLength(10), MaxLength(256)]
        public string PictureAlt { get;  set; }

        [Required, MinLength(10), MaxLength(256)]
        public string PictureTitle { get;  set; }

        public List<ProductViewModel> Products { get; set; }
    }
}
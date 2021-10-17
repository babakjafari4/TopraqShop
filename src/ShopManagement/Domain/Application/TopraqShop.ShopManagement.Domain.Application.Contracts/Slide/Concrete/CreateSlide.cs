using System.ComponentModel.DataAnnotations;

namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Concrete
{
    public class CreateSlide
    {
        [Required, MaxLength(1000), MinLength(3)]
        public string Picture { get;  set; }
        
        [Required, MaxLength(500), MinLength(3)]
        public string PictureAlt { get;  set; }
        
        [Required, MaxLength(500), MinLength(3)]
        public string PictureTitle { get;  set; }
        
        [Required, MaxLength(255), MinLength(3)]
        public string Heading { get;  set; }
        
        [MaxLength(255), MinLength(3)]
        public string Title { get;  set; }

        [MaxLength(255), MinLength(3)]
        public string Text { get;  set; }
        
        [Required, MaxLength(50), MinLength(3)]
        public string ButtonText { get;  set; }

        [Required, MaxLength(256), MinLength(10)]
        public string Link { get; set; }


        public CreateSlide()
        {
            
        }

        public CreateSlide(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string buttonText, string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            ButtonText = buttonText;
            Link = link;
        }
    }
}
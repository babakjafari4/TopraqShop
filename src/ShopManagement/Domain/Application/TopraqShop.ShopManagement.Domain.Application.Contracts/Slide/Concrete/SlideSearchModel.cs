namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Concrete
{
    public class SlideSearchModel
    {
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }

        public SlideSearchModel()
        {
            
        }

        public SlideSearchModel(string picture, string pictureAlt, string pictureTitle, string heading, string title)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
        }
    }
}
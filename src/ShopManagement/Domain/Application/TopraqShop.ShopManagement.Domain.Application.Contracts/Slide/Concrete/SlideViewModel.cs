namespace TopraqShop.ShopManagement.Domain.Application.Contracts.Slide.Concrete
{
    public class SlideViewModel
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ButtonText { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
        public string Status { get; set; }

        public SlideViewModel()
        {
            
        }

        public SlideViewModel(int id, string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string buttonText, string createdOn, string modifiedOn, string status)
        {
            Id = id;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            ButtonText = buttonText;
            CreatedOn = createdOn;
            ModifiedOn = modifiedOn;
            Status = status;
        }
    }
}
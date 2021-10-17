namespace TopraqShop.Query.Base.Contracts.Slide
{
    public class HeroSlideQueryModel
    {
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Heading { get;  set; }
        public string Title { get;  set; }
        public string Text { get;  set; }
        public string ButtonText { get;  set; }
        public string Link { get; set; }

        public HeroSlideQueryModel(string picture, string pictureAlt, string pictureTitle, string heading, string title, string text, string buttonText, string link)
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
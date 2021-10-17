using System;
using TopraqShop.Framework.Base.Domain;

namespace TopraqShop.ShopManagement.Domain.Base.SlideAggregate
{
    public class SlideBase : EntityBase<int>
    {
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Heading { get; private set; }
        public string Title { get; private set; }
        public string Text { get; private set; }
        public string ButtonText { get; private set; }
        public string Link { get; private set; }


        public SlideBase(string picture, string pictureAlt, string pictureTitle, string heading, string title,
            string text, string buttonText, string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            ButtonText = buttonText;
            Link = link;

            CreatedOn = DateTime.Now;
            ModifiedOn = DateTime.Now;
            Status = (byte) SlideStatus.Draft;

            CheckInvariants();
        }

        public void Edit(string picture, string pictureAlt, string pictureTitle, string heading, string title,
            string text, string buttonText, string link)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Heading = heading;
            Title = title;
            Text = text;
            ButtonText = buttonText;
            Link = link;

            ModifiedOn = DateTime.Now;
            
            CheckInvariants();
        }

        public void Activate()
        {
            Status = (byte) SlideStatus.Active;
            ModifiedOn = DateTime.Now;
        }

        public void Deactivate()
        {
            Status = (byte) SlideStatus.Inactive;
            ModifiedOn = DateTime.Now;
        }

        public void Delete()
        {
            Status = (byte) SlideStatus.Deleted;
            ModifiedOn = DateTime.Now;
        }


        public void CheckInvariants()
        {
            if (string.IsNullOrWhiteSpace(Picture))
                throw new NullReferenceException($"{nameof(Picture)} cannot be null!");
            if (string.IsNullOrWhiteSpace(PictureAlt))
                throw new NullReferenceException($"{nameof(PictureAlt)} cannot be null!");
            if (string.IsNullOrWhiteSpace(PictureTitle))
                throw new NullReferenceException($"{nameof(PictureTitle)} cannot be null!");
            if (string.IsNullOrWhiteSpace(Heading))
                throw new NullReferenceException($"{nameof(Heading)} cannot be null!");
            if (string.IsNullOrWhiteSpace(ButtonText))
                throw new NullReferenceException($"{nameof(ButtonText)} cannot be null!");
        }
    }
}
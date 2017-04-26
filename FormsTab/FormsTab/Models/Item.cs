using System;
using FormsTest.Helpers;
using Xamarin.Forms;

namespace FormsTab.Models
{
    public class Item : BaseDataObject
    {
        string text = string.Empty;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        string description = string.Empty;
        public string Description
        {
            get { return description; }
            set { SetProperty(ref description, value); }
        }

        string imageurl = string.Empty;
        public string ImageUrl
        {
            get { return imageurl; }
            set { SetProperty(ref imageurl, value); }
        }

        public UriImageSource UrlSource
        {
            get
            {
                if (string.IsNullOrEmpty(ImageUrl))
                    return null;
                
                return new UriImageSource
                {
                    Uri = new Uri(ImageUrl),
                    CachingEnabled = true,
                    CacheValidity = new TimeSpan(5, 0, 0, 0)
                };
            }
        }

        DateTime postTime;
        public DateTime PostTime
        {
            get { return postTime; }
            set { SetProperty(ref postTime, value); }
        }

        public string TimeAgo
        {
            get { return PostTime.TimeAgo(); }
        }
    }
}

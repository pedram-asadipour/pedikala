using System;
using _01_Framework.Domain;

namespace BannerManagement.Domain.SliderAgg
{
    public class Slider : EntityBase
    {
        public string TitleOne { get; private set; }
        public string TitleTwo { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string Link { get; private set; }
        public DateTime LifeTime { get; private set; }
        public bool IsRemove { get; private set; }

        private Slider(DateTime lifeTime)
        {
            LifeTime = lifeTime;
        }

        public Slider(string titleOne, string titleTwo, string description, string image, string imageAlt,
            string imageTitle, string link, DateTime lifeTime)
        {
            TitleOne = titleOne;
            TitleTwo = titleTwo;
            Description = description;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Link = link;
            LifeTime = lifeTime;
            IsRemove = false;
        }

        public void Edit(string titleOne, string titleTwo, string description, string image, string imageAlt,
            string imageTitle, string link, DateTime lifeTime)
        {
            TitleOne = titleOne;
            TitleTwo = titleTwo;
            Description = description;

            if (!string.IsNullOrWhiteSpace(image))
                Image = image;

            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            Link = link;
            LifeTime = lifeTime;
        }

        public void Removed()
        {
            IsRemove = true;
        }

        public void Restore()
        {
            IsRemove = false;
        }
    }
}
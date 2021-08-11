using System;
using _01_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ImageTitle { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Keyword { get; private set; }
        public string MetaDescription { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string CanonicalAddress { get; private set; }
        public long CategoryId { get; private set; }
        public ArticleCategory Category { get; private set; }

        protected Article()
        {
        }

        public Article(string title, string image, string imageAlt, string imageTitle, string shortDescription,
            string description, string keyword, string metaDescription, DateTime publishDate, string canonicalAddress,
            long categoryId)
        {
            Title = title;
            Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            ShortDescription = shortDescription;
            Description = description;
            Keyword = keyword;
            MetaDescription = metaDescription;
            PublishDate = publishDate;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }

        public void Edit(string title, string image, string imageAlt, string imageTitle, string shortDescription,
            string description, string keyword, string metaDescription, DateTime publishDate, string canonicalAddress,
            long categoryId)
        {
            Title = title;
            if (!string.IsNullOrWhiteSpace(image))
                Image = image;
            ImageAlt = imageAlt;
            ImageTitle = imageTitle;
            ShortDescription = shortDescription;
            Description = description;
            Keyword = keyword;
            MetaDescription = metaDescription;
            PublishDate = publishDate;
            CanonicalAddress = canonicalAddress;
            CategoryId = categoryId;
        }
    }
}
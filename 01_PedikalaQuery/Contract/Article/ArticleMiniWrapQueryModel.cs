﻿namespace _01_PedikalaQuery.Contract.Article
{
    public class ArticleMiniWrapQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ImageAlt { get; set; }
        public string ImageTitle { get; set; }
        public string PublishDate { get; set; }
    }
}